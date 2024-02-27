using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;
    [SerializeField] private DialogueService dialogueService;
    void Awake()
    {
        if (dialogueService == null)
        {
            Debug.LogError("DialogueService is not assigned in the inspector.");
        }
    }

    public void StartDialogue(string dialogueId)
    {
        Dialogue dialogue = dialogueService.GetDialogue(dialogueId);
        if (dialogue != null)
        {
            PauseGame();
            dialogueUI.ShowDialogue(dialogue);
        }
        else
        {
            Debug.LogError("Dialogue with ID " + dialogueId + " not found.");
        }
    }

    public void OnOptionSelected(DialogueOption option)
    {
        if (!string.IsNullOrEmpty(option.leadsToDialogueId))
        {
            StartDialogue(option.leadsToDialogueId);
        }
        else
        {
            EndDialogue();
        }
    }

    public void EndDialogue()
    {
        ResumeGame();
        dialogueUI.HideDialogue();
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}
