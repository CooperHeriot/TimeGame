using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGoAway : MonoBehaviour
{
    private Animator anim;

    public bool goin;

    //public float timer;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (goin == true)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    public void die()
    {
        if (anim != null)
        {
            anim.SetBool("Die", true);
        }

    }
}
