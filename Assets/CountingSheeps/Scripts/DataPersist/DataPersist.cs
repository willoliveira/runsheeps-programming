using UnityEngine;
using System;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataPersist : MonoBehaviour {

	void OnGUI()
	{
		if (GUI.Button(new Rect(0, 0, 100, 30), "Save"))
		{
			//Save<GameData>();
		}
		if (GUI.Button(new Rect(0, 40, 100, 30), "Load"))
		{
			Debug.Log("Load: " + Application.persistentDataPath);
			//Load();
		}
	}

	
	public static void Save<T>(DataObject data)
		where T : DataObject
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file;
		if (File.Exists(Application.persistentDataPath + "/GameData.dat"))
		{
			Debug.Log("Exists");
			file = File.Open(Application.persistentDataPath + "/GameData.dat", FileMode.Open);
		} 
		else
		{
			Debug.Log("Not Exists");
			file = File.Create(Application.persistentDataPath + "/GameData.dat");
		}

		T d = (T) data;

		Debug.Log(d);

		bf.Serialize(file, data);
		file.Close();
	}

	public static DataObject Load<T>()
		where T : DataObject
	{
		if (File.Exists(Application.persistentDataPath + "/GameData.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/GameData.dat", FileMode.Open);
			
			T data = (T) bf.Deserialize(file);
			file.Close();

			return data;
		}
		return null;
	}
}

[Serializable]
class PlayerData
{
	public float health;
	public float experience;
}
