using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSCounter : MonoBehaviour
{
    public TextMeshProUGUI Tpro;

    // Update is called once per frame
    void Update()
    {
        Tpro.text = ("Fps:" + Time.deltaTime);
    }
}
