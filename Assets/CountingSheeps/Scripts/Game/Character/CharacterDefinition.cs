using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Data", menuName = "")]
public class CharacterDefinition : ScriptableObject {

	public string nameCharacter;
	public int order;
	public Texture2D image;
	public int price;
	public bool isAvaliable;
}
