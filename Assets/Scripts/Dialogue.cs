using System;
using System.Collections.Generic;

[Serializable]
public class Dialogue
{
    public string id;
    public string characterName;
    public List<DialogueLine> lines;
}