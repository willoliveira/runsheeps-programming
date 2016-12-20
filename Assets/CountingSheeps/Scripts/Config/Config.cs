using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Data", menuName = "")]
public class Config : ScriptableObject
{
	public CharacterDefinition CharacterSelect;
	public List<CharacterDefinition> ListCharacters;
}
