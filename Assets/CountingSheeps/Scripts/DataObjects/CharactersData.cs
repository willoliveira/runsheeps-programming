using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class CharactersData : DataObject {

    [SerializeField]
    public List<CharacterDefinition> ListCharacters = new List<CharacterDefinition>();
    [SerializeField]
    public CharacterDefinition CharacterSelect;
    [SerializeField]
    public CharacterDefinition DefaultCharacter;
}
