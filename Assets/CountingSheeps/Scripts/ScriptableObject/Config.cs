using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Data", menuName = "")]
public class Config : ScriptableObject
{
	public CharacterDefinition CharacterSelect;
	public CharacterDefinition DefaultCharacter;
	public List<CharacterDefinition> ListCharacters = new List<CharacterDefinition>();

	public int coins;

	public void OnEnable()
	{
		if (this.CharacterSelect == null)
		{
			this.CharacterSelect = this.DefaultCharacter;
		}
	}
}
