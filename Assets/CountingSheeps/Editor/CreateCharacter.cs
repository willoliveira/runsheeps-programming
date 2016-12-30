using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateCharacter {

	[MenuItem("Assets/Create/Character")]
	public static void Create()
	{
		CharacterDefinition asset = ScriptableObject.CreateInstance<CharacterDefinition>();

		AssetDatabase.CreateAsset(asset, "Assets/CountingSheeps/Data/Characters/NewCharacter.char");
		AssetDatabase.SaveAssets();

		EditorUtility.FocusProjectWindow();

		Selection.activeObject = asset;
	}
}
