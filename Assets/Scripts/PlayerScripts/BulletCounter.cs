using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletCounter : MonoBehaviour
{
    public TextMeshProUGUI tp;

    public Gunbehav gb;
    public GameObject dots;
    public SpriteRenderer SR;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gb.currentAmmo < 1)
        {
            tp.text = ("Reloading");
        } else
        {
            tp.text = (gb.currentAmmo + "/" + gb.maxAmmo);
        }
        

        if (gb.currentAmmo < 1)
        {
            dots.SetActive(true);
            SR.enabled = false;
        } else
        {
            dots.SetActive(false);
            SR.enabled = true;
        }
    }
}
