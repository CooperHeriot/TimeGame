using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletCounter : MonoBehaviour
{
    public TextMeshProUGUI tp;

    public Gunbehav gb;
    public GameObject dots;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tp.text = (gb.currentAmmo + "/" + gb.maxAmmo);

        if (gb.currentAmmo < 1)
        {
            dots.SetActive(true);
        } else
        {
            dots.SetActive(false);
        }
    }
}
