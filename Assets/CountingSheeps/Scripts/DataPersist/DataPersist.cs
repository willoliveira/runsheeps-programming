using UnityEngine;
using System;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataPersist : MonoBehaviour
{

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


    public static void Save<T>(string source, DataObject data)
        where T : DataObject
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file;
        if (File.Exists(Application.persistentDataPath + "/" + source))
        {
            Debug.Log("Exists: " + source);
            file = File.Open(Application.persistentDataPath + "/" + source, FileMode.Open);
        }
        else
        {
            Debug.Log("Not Exists: " + source);
            file = File.Create(Application.persistentDataPath + "/" + source);
        }

        bf.Serialize(file, data);
        file.Close();
    }

    public static DataObject Load<T>(string source)
        where T : DataObject
    {
        if (File.Exists(Application.persistentDataPath + "/" + source))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + source, FileMode.Open);

            T data = (T)bf.Deserialize(file) as T;
            file.Close();

            return data;
        }
        return null;
    }
}