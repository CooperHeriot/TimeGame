using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatTracker : MonoBehaviour
{
    public bool done;

    public float timeT, killed, Tiemlins;
    public TextMeshProUGUI T, K, TL;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (done == false)
        {
            timeT += 1 * Time.deltaTime;
        }
        
        if (done == true)
        {
            T.text = ("" + timeT.ToString("F0") + " Seconds");
            K.text = ("" + killed);
            TL.text = ("" + Tiemlins);
        }
    }

    public void KilledPlusOne()
    {
        killed += 1;
    }

    public void TPlusOne()
    {
        Tiemlins += 1;
    }
}
