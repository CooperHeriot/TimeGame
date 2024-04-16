using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBehav : MonoBehaviour
{
    public AudioClip Sound;
    public AudioSource AS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(AudioClip _audio)
    {
        AS.clip = _audio;
        AS.Play();
    }
}
