using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDialogueNode : DialogueNode
{
    [SerializeField] private DialogueNode m_NextNode;

    public DialogueNode GetNextNode()
    {
        return m_NextNode;
    }
}