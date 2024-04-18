using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleStop : MonoBehaviour
{
    public ParticleSystem PS;
    public float threshHold = 1000;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PS.particleCount >= threshHold)
        {
            PS.Pause();
            GetComponent<ParticleStop>().enabled = false;
        }
    }
}
