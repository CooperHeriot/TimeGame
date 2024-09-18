using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReseTtSlider : MonoBehaviour
{
    public string Pref;
    private Slider slid;
    // Start is called before the first frame update
    void Start()
    {
        slid = GetComponent<Slider>();

        if (PlayerPrefs.GetFloat(Pref) > 0)
        {
            slid.value = PlayerPrefs.GetFloat(Pref);
        }        
    }
}
