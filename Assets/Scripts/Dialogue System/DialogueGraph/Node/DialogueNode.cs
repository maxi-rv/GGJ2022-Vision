using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DialogueNode : MonoBehaviour
{
    [SerializeField] private NarrationLine m_DialogueLine;

    public NarrationLine GetDialogueLine()
    {
        return m_DialogueLine;
    }
}