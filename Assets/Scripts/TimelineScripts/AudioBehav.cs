using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBehav : MonoBehaviour
{
    public AudioClip Sound;
    public AudioSource AS;

    public GameObject SpawnPos;
    public GameObject SoundObj;
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
        //AS.clip = _audio;
        //AS.Play();
        GameObject Sund = Instantiate(SoundObj, SpawnPos.transform.position, SpawnPos.transform.rotation);
        Sund.GetComponent<AudioSource>().clip = _audio;
        Sund.GetComponent<AudioSource>().panStereo = AS.panStereo;
        Sund.GetComponent<AudioSource>().Play();
    }
}
