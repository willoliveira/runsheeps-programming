using UnityEngine;
using UnityEditor;
using System.Collections;

public class CreateConfig {

	[MenuItem("Assets/Create/ConfigFile")]
	public static void Create()
	{
		Config asset = ScriptableObject.CreateInstance<Config>();

		AssetDatabase.CreateAsset(asset, "Assets/CountingSheeps/Data/Config/Config.asset");
		AssetDatabase.SaveAssets();

		EditorUtility.FocusProjectWindow();

		Selection.activeObject = asset;
	}
}
