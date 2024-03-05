using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetValue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("point", -1);

        if (PlayerPrefs.GetInt("Once") == 0)
        {
            PlayerPrefs.SetInt("Scren", 1);
            PlayerPrefs.SetInt("Once", 1);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
