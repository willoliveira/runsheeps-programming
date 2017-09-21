using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (MapGenerator))]
public class MapGeneratorEditor : Editor {
	
	public override void OnInspectorGUI()
	{
		MapGenerator mapGenarator = (MapGenerator) target;
		
		if (DrawDefaultInspector())
		{
			if (mapGenarator.autoUpdate)
			{
				mapGenarator.GenerateMap();
			}
		}

		if (GUILayout.Button("Generate"))
		{
			mapGenarator.GenerateMap();
		}
	}
}
