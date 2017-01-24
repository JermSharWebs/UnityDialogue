# UnityDialogue
An Unity C# script that shows dialogues and allows to use a XML to map the game dialogue script. Using a XML for game dialogues provides a way for non-developers in the team to read and write dialogues without much effort.

Altough the system is fully functional, it should be used as an start point for game developers to create their own dialogue system.

#How it works
1. The entire script containing all dialogues is a XML file (script.xml).
2. The Talk.cs script is attached to a GameObject that the player must interact with to trigger the dialogue. This GameObject contains the information of which lines of the script it must show and a Collider to trigger the dialogue.
3. While the players stands inside the Collider area, if the key "E" is pressed the dialogue will be shown in the Text component in the Canvas with the tag "Dialogue".

#Contents
- DialogueSerializer.cs: Reads the XML script and transforms it into an object of the class Script.
- Script.cs: Provides the class that models the XML.
- Talk.cs: Collider triggers and GameObject detection.
- Script.xml: XML used as example.
