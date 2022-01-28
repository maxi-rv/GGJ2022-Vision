using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueGraph : MonoBehaviour
{
    [SerializeField]
    private DialogueNode m_FirstNode;

    public DialogueNode GetFirstNode()
    {
        return m_FirstNode;
    }
}