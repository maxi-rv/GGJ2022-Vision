using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrationLine : MonoBehaviour
{
    [SerializeField] private NarrationCharacter m_Speaker;
    [SerializeField] private string m_Text;

    public NarrationCharacter GetSpeaker()
    {
        return m_Speaker;
    }

    public string GetText()
    {
        return m_Text;
    }
}