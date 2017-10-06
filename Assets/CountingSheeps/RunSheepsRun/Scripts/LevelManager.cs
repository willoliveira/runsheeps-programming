using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	private static LevelManager levelManager;

	public static LevelManager Instance
	{
		get
		{
			if (!levelManager)
			{
				levelManager = FindObjectOfType(typeof(LevelManager)) as LevelManager;

				if (!levelManager)
				{
					Debug.LogError("There needs to be one active GameManger script on a GameObject in your scene.");
				}
			}
			return levelManager;
		}
	}

}
