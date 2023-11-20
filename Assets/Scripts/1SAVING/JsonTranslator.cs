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
    }

    public static void LoadFromJSON()
    {

    }
}
