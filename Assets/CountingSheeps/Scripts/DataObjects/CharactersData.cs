using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class CharactersData : DataObject {

    public List<CharacterDefinition> ListCharacters = new List<CharacterDefinition>();
    public CharacterDefinition CharacterSelect;
    public CharacterDefinition DefaultCharacter;
}
