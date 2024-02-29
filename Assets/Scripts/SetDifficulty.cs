using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetDifficulty : MonoBehaviour
{
    public int diffuculty;

    public string Scene;
    //1 = standard
    //2 = chaotic
    //3 = paradoxical
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScenePlusDifficulty(int _dif)
    {
        PlayerPrefs.SetInt("Difficulty", _dif);
        print(_dif);
        SceneManager.LoadScene(Scene);
    }
}
