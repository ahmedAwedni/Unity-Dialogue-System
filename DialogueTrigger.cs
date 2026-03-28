using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Dialogue Content")]
    public DialogueData dialogueData;
    
    [Header("System Reference")]
    public DialogueManager dialogueManager; 

    public void TriggerDialogue()
    {
        if (dialogueManager != null && dialogueData != null)
        {
            dialogueManager.StartDialogue(dialogueData);
        }
        else
        {
            Debug.LogWarning("DialogueManager or DialogueData is missing on the trigger!");
        }
    }
}
