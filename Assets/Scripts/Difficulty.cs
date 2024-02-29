using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    public int difficulty;
    //1 = standard
    //2 = chaotic
    //3 = paradoxical
    void Start()
    {
        difficulty = PlayerPrefs.GetInt("Difficulty");

        if (difficulty == 0)
        {
            difficulty = 1;
        }

        if (difficulty == 1)
        {
            GetComponent<TimelineManager>().maxAmount = 2;
        } else
        {
            GetComponent<TimelineManager>().maxAmount = 4;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
