using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomiseAudio : MonoBehaviour
{
    public AudioSource AS;
    [Header("Pitch")]
    public bool pitch;
    public float prange = 0.1f;
    public float pbase;
    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
        pbase = AS.pitch;
        if (pitch == true)
        {
            AS.pitch = Random.Range(pbase - prange, pbase + prange);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        //RandomiseAud();
    }

    public void RandomiseAud()
    {
        if (pitch == true)
        {
            AS.pitch = Random.Range(pbase - prange, pbase + prange);
        }
    }
}
