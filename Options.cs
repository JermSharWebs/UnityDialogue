using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Options : MonoBehaviour {

    // public static GameObject options;

    public static GameObject op1;
    public static GameObject op2;
    public static GameObject op3;

    public static Text opText1;
    public static Text opText2;
    public static Text opText3;

    void Start () {

        // options = GameObject.FindWithTag("options");
        // options.SetActive(false); //desativa opções

        
        opText1 = GameObject.FindWithTag("opText1").GetComponent<Text>();
        opText2 = GameObject.FindWithTag("opText2").GetComponent<Text>();
        opText3 = GameObject.FindWithTag("opText3").GetComponent<Text>();

        op1 = GameObject.FindWithTag("option1");
        op2 = GameObject.FindWithTag("option2");
        op3 = GameObject.FindWithTag("option3");

        op1.SetActive(false);
        op2.SetActive(false);
        op3.SetActive(false);

        op1.GetComponent<Button>().onClick.AddListener(() => { Debug.Log("Correct (+30 pontos)"); });
        op2.GetComponent<Button>().onClick.AddListener(() => { Debug.Log("Maybe (+20 pontos)"); });
        op3.GetComponent<Button>().onClick.AddListener(() => { Debug.Log("Wrong (0 pontos)"); });


        // cada objeto é uma tag - melhor abordagem?

    }


}
