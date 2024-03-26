using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        LoadGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SaveGame();
        }
    }
    public void SaveGame()
    {
        JsonTranslator.CurrentSavedData.SensInGame.Clear();
        foreach(SaveableObject eachOject in GameObject.FindObjectsOfType<SaveableObject>())
        {
            eachOject.UpdatemyData();
            JsonTranslator.CurrentSavedData.sens = eachOject.GetComponent<SaveableObject>().MyData.theSensitivity;

            JsonTranslator.CurrentSavedData.SensInGame.Add(eachOject.MyData);
        }

        JsonTranslator.SaveToJSON();
        //print("saved");
    }
    public void LoadGame()
    {
        JsonTranslator.LoadFromJSON();
        foreach(MouseData eachOject in JsonTranslator.CurrentSavedData.SensInGame)
        {

            eachOject.myObject.GetComponent<SaveableObject>().MyData = eachOject;
            eachOject.myObject.GetComponent<SaveableObject>().RestoreFromData();
        }

        JsonTranslator.LoadFromJSON();
        //print("loaded");
    }
}
