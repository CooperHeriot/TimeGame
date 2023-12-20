using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Combatlog : MonoBehaviour
{

    public bool done;

    public float ttime, kill;

    public TextMeshProUGUI T, K;

    public bool destoyee;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (done == false)
        {
           // ttime += 1 * Time.deltaTime;
        }       

        T.text = ("Time:" + ttime.ToString("F0") + " Seconds");
        K.text = ("Kills:" + kill);

        if (destoyee == true)
        {
            Destroy(gameObject);
        }
    }
    public void NewKill()
    {
        kill += 1;
    }
}
