using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueData
{
    public Dialogue[] dialogues;
}

public class DialogueService : MonoBehaviour
{
    private Dictionary<string, Dialogue> dialogues = new Dictionary<string, Dialogue>();

    void Start()
    {
        LoadDialogues();
    }

    void LoadDialogues()
    {
        TextAsset dialogueJson = Resources.Load<TextAsset>("dialogues");
        if (dialogueJson == null)
        {
            Debug.LogError("Dialogue json file not found.");
            return;
        }

        Dialogue[] loadedDialogues = JsonHelper.FromJson<Dialogue>(dialogueJson.text);

        foreach (var dialogue in loadedDialogues)
        {
            dialogues[dialogue.id] = dialogue;
        }
    }


    public Dialogue GetDialogue(string id)
    {
        if (dialogues.TryGetValue(id, out Dialogue dialogue))
        {
            return dialogue;
        }
        Debug.LogError("Dialogue with ID " + id + " not found.");
        return null;
    }
}
