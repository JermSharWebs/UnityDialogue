using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Talk : MonoBehaviour {

    // OPTION ACCESS ----------------
    // dialogue[i].Options[i].Awnser;
    // ------------------------------

    [SerializeField] private int startLine;
    [SerializeField] private int endLine;
    public static Text speechLine; // Acessível por outras classes
    public System.Collections.Generic.List<ScriptModel.DialogueScript.Dialogue> dialogue;
    public bool running = false;

    public void Start() // Inicia objetos e serialização
    {
        speechLine = GameObject.FindWithTag("Dialogue").GetComponent<Text>();
        speechLine.enabled = false;
        dialogue = DialogueSerializer.deserializeScript(); // Recebe o script e guarda na variável
    }

    public IEnumerator StartDialogue(int start, int end) // Inicia o diálogo
    {
        int i,j;

        bool getInput = false;

        for (i = start; i <= end; i++) {
            speechLine.text = dialogue[i].Speaker + ": " + dialogue[i].Speech; // Define o formato da linha de diálogo
            
            //opText2.text = dialogue[i].Options[1].Awnser;
            //opText3.text = dialogue[i].Options[2].Awnser;

            if (dialogue[i].Options[i].Question != "") // OPTIONS START
            {
                for(j=0; j<3; j++)
                {
                    if (dialogue[i].Options[j].Question != "")
                    {
                        if (j == 0)
                        {
                            Options.op1.SetActive(true);
                            Options.opText1.text = dialogue[i].Options[0].Question;
                        }
                        else if (j == 1)
                        {
                            Options.op2.SetActive(true);
                            Options.opText2.text = dialogue[i].Options[1].Question;
                        }
                        else if (j == 2)
                        {
                            Options.op3.SetActive(true);
                            Options.opText3.text = dialogue[i].Options[2].Question;
                        }
                    }

                }
            } 
            else
            {
                Options.op1.SetActive(false);
                Options.op2.SetActive(false);
                Options.op3.SetActive(false);
            }
            // OPTIONS END

            while (!getInput)
                {
                    while (Input.GetKeyDown("e"))
                    {
                        getInput = true;
                        yield return null;
                        
                    }
                    yield return null;
                    
                }
                getInput = false;
        }
        yield return null;
        Debug.Log("Terminou o diálogo");
        running = false;
    }

    IEnumerator OnTriggerStay(Collider c)
    {
        if (Input.GetKeyUp("e")) // Bugado: retorna o movimento antes do necessário
        {
            FirstPersonController.m_WalkSpeed = 0;
            speechLine.enabled = true;
            if (running == false)
            {
                running = true;
                yield return StartCoroutine(StartDialogue(startLine, endLine)); // Define o diálogo do NPC ( Parametro 1: Inicio da fala | Parametro 2: Final )
            }
        }
        FirstPersonController.m_WalkSpeed = 5;
    }

    IEnumerator OnTriggerExit(Collider c)
    {
        StopCoroutine("StartDialogue");
        //running = false; Tava bugando.
        yield return null;
        speechLine.enabled = false;
        Options.op1.SetActive(false);
        Options.op2.SetActive(false);
        Options.op3.SetActive(false);
    }


}
