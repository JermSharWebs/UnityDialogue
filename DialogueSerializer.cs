using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System;
using System.Collections.Generic;
using ScriptModel;
using Script;
using UnityEditor;
using UnityEngine.UI;

public class DialogueSerializer : MonoBehaviour
{
    public static List<ScriptModel.DialogueScript.Dialogue> deserializeScript()
    {
        var deserializer = new XmlSerializer(typeof(DialogueScript));
        StreamReader reader = new StreamReader(Application.dataPath + "\\Scripts\\DialogueScripts\\script.xml");
        var talks = ((DialogueScript)deserializer.Deserialize(reader)).Dialogues;
        reader.Close();

        return talks;
    }
}