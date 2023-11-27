using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class JsonTranslator {
    public static SavedData CurrentSavedData = new SavedData();

    public const string SaveDirectory = "/SavedDate/";
    public const string FileName = "mySavedGame.sav";

    public static void SaveToJSON()
    {
        string dir = Application.persistentDataPath + SaveDirectory;
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        string json = JsonUtility.ToJson(CurrentSavedData, true);
        File.WriteAllText(dir + FileName, json);
        
        GUIUtility.systemCopyBuffer = dir;
    }

    public static void LoadFromJSON()
    {
        string dir = Application.persistentDataPath + SaveDirectory + FileName;

        if (File.Exists(dir))
        {
            string json = File.ReadAllText(dir);
            CurrentSavedData = JsonUtility.FromJson<SavedData>(json);
        }
        else
        {
            Debug.Log("dint work file not found");
        }
    }
}
