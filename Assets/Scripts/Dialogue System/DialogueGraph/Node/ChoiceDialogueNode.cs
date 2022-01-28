using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceDialogueNode : DialogueNode
{
    [SerializeField] private SingleChoice[] m_Choices;

    public SingleChoice[] GetChoices()
    {
        return m_Choices;
    }
}

public class SingleChoice: MonoBehaviour
{
    [SerializeField] private string m_ChoicePreview;
    [SerializeField] private DialogueNode m_ChoiceNode;

    public string GetChoicePreview()
    {
        return m_ChoicePreview;
    }

    public DialogueNode GetChoiceNode()
    {
        return m_ChoiceNode;
    }
}