// 3. DialogueManager.cs
using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static event Action<DialogueLine> OnLineStarted;
    public static event Action OnDialogueEnded;

    private Queue<DialogueLine> linesQueue = new Queue<DialogueLine>();
    public bool isDialogueActive { get; private set; }

    public void StartDialogue(DialogueData dialogueData)
    {
        if (isDialogueActive) return;

        isDialogueActive = true;
        linesQueue.Clear();

        foreach (DialogueLine line in dialogueData.lines)
        {
            linesQueue.Enqueue(line);
        }

        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if (linesQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine currentLine = linesQueue.Dequeue();
        OnLineStarted?.Invoke(currentLine);
    }

    private void EndDialogue()
    {
        isDialogueActive = false;
        OnDialogueEnded?.Invoke();
    }
}
