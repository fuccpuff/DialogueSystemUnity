using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DialogueTrigger : MonoBehaviour
{
    public string dialogueId;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
            if (dialogueManager != null)
            {
                dialogueManager.StartDialogue(dialogueId);
            }
        }
    }
}
