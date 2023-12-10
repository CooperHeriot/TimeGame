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
            T.text = ("" + timeT);
            K.text = ("" + timeT);
            TL.text = ("" + timeT);
        }
    }

    public void KilledPlusOne()
    {
        killed += 1;
    }
}
