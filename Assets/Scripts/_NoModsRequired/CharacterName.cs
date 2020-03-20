using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple object to hold a complete character name
/// 
/// NOTE: Provided with framework, no modification required
/// TODO: Nothing
///     This is where you could add additional names or categories of information to a character or where you would add rich text
///         to its character name when requested by UI Controllers.
/// </summary>
[System.Serializable]
public struct CharacterName
{
    [SerializeField]
    public string firstName, lastName, nickname, descriptor;

    public CharacterName(string _first, string _last, string _nickname, string _descriptor)
    {
        firstName = _first;
        lastName = _last;
        nickname = _nickname;
        descriptor = _descriptor;
    }

    public string GetFullCharacterName()
    {
        return firstName + " the " + descriptor + " '" + nickname + "', " + lastName;
    }
}
