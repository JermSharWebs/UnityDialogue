using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ScriptModel
{
    [XmlRoot("script")]
    public class DialogueScript
    {
        [XmlElement("dialogue")]
        public List<Dialogue> Dialogues = new List<Dialogue>();

        public class Dialogue
        {

            [XmlAttribute("id")]
            public int Id { get; private set; }

            [XmlElement("speaker")]
            public string Speaker { get; set; }

            [XmlElement("speech")]
            public string Speech { get; set; }

            [XmlElement("option")]
            public List<Option> Options = new List<Option>();

        }

        public class Option
        {

            [XmlAttribute("id")]
            public int Id { get; private set; }

            [XmlElement("question")]
            public string Question { get; set; }

            [XmlElement("awnser")]
            public string Awnser { get; set; }
        }

    }
}