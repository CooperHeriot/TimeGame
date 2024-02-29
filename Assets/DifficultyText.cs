using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DifficultyText : MonoBehaviour
{
    public TextMeshProUGUI tp;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Difficulty") == 3)
        {
            tp.text = ("Paradoxical");
        }
        if (PlayerPrefs.GetInt("Difficulty") == 2)
        {
            tp.text = ("Chaotic");
        }
        if (PlayerPrefs.GetInt("Difficulty") == 1)
        {
            tp.text = ("Standard");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
