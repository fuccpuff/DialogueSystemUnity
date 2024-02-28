using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    public TextMeshProUGUI characterNameText;
    public TextMeshProUGUI dialogueText;
    public GameObject optionsContainer;
    public GameObject optionPrefab;

    private void ClearOptions()
    {
        foreach (Transform child in optionsContainer.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void ShowDialogue(Dialogue dialogue)
    {
        gameObject.SetActive(true);
        characterNameText.text = dialogue.characterName;
        dialogueText.text = dialogue.lines[0].text;
        ClearOptions();

        foreach (var option in dialogue.lines[0].options)
        {
            GameObject optionButton = Instantiate(optionPrefab, optionsContainer.transform);
            optionButton.GetComponentInChildren<TextMeshProUGUI>().text = option.text;
            optionButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                FindObjectOfType<DialogueManager>().OnOptionSelected(option);
            });
        }
    }

    public void HideDialogue()
    {
        gameObject.SetActive(false);
        ClearOptions();
        characterNameText.text = "";
        dialogueText.text = "";
    }
}
