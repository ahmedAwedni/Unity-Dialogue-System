// 2. DialogueData.cs
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue System/Dialogue")]
public class DialogueData : ScriptableObject
{
    [Header("Conversation Lines")]
    public List<DialogueLine> lines = new List<DialogueLine>();
}
