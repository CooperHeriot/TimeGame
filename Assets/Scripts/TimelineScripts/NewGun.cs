using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGun : MonoBehaviour
{
    //asd
    public GameObject ThisTimeLine;
    private Gunbehav GB;

    public TimelineManager TM;

    [Header("Attributes")]
    public Sprite GunSprite;
    public GameObject GunMod;
    public float FRate;
    public bool Auto;
    public GameObject Bullet;
    public float Ammo = 1;

    public bool Replace;
    //public bool StartGun;
    // Start is called before the first frame update
    void Start()
    {
        TM = FindObjectOfType<TimelineManager>();

        GB = ThisTimeLine.GetComponent<TimelineBehav>().Player.GetComponent<Gunbehav>();
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.Q))
        {
            MakeAnew();
        }*/
    }

    public void MakeAnew()
    {
        TM.createNewTimeline(ThisTimeLine,  GunSprite,  FRate,  Auto,  Bullet, Ammo, GunMod);

        FindObjectOfType<StatTracker>().GetComponent<StatTracker>().TPlusOne();
    }

    public void SwapGun()
    {
        GB.NewGun(GunSprite, FRate, Auto, Bullet, Ammo, GunMod);
    }

   /* private void OnCollisionEnter(Collision collision)
    {
         if (collision.gameObject.GetComponent<PlayerMove>() != null)
         {
             MakeAnew();
         }
        //MakeAnew();
        print("dsad");
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMove>() != null && TM != null)
        {            
            other.gameObject.GetComponent<PlayerHealth>().PlayerHeal(3);

            transform.parent = null;

            Destroy(gameObject);
            if (TM.currentAmount < TM.maxAmount)
            {
                //Destroy(gameObject);
                if (Replace == false)
                {
                    ThisTimeLine.GetComponent<TimelineBehav>().activateImg();
                    MakeAnew();
                } else
                {
                    SwapGun();
                }
                
            } else
            {
                //Destroy(gameObject);

                SwapGun();
            }


            //other.gameObject.GetComponent<PlayerHealth>().PlayerHeal(3);
        }

        
        //MakeAnew();
        //print("dsad");
    }
}
