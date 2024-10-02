using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVariablersAtAStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("bb") == 0)
        {
            PlayerPrefs.SetInt("bb", 1);
            PlayerPrefs.SetFloat("senss", 3);

            PlayerPrefs.SetFloat("MUSv", -10);
            PlayerPrefs.SetFloat("SFXv", 10);
        }
    }
}
