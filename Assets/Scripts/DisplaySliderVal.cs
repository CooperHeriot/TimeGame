using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySliderVal : MonoBehaviour
{
    public Slider slid;
    public TextMeshProUGUI tx;
    // Update is called once per frame
    void Update()
    {
        tx.text = slid.value.ToString("F2");
    }
}
