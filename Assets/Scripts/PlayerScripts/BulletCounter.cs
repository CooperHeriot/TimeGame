using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletCounter : MonoBehaviour
{
    public TextMeshProUGUI tp;

    public Gunbehav gb;
    public GameObject dots;
    private Animator anim;
    public Animator anim2;
    private bool once;
    public SpriteRenderer SR;
    // Start is called before the first frame update
    void Start()
    {
        anim = dots.GetComponent<Animator>();
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
            //dots.SetActive(true);
            //anim.Play("Reloading");
            anim.SetBool("Spin", true);
            SR.enabled = false;

            if (once == false)
            {
                anim2.Play("GunReload");
                once = true;
            }
           
        } else
        {
            anim.SetBool("Spin", false);
            //dots.SetActive(false);
            SR.enabled = true;

            once = false;
        }
    }
}
