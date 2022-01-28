using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrationCharacter : MonoBehaviour
{
    [SerializeField] private string m_CharacterName;

    public string GetCharacterName()
    {
        return m_CharacterName;
    }
}