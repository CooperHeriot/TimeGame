using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public AudioClip Soun;
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
        TM.createNewTimeline(ThisTimeLine,  GunSprite,  FRate,  Auto,  Bullet, Ammo, GunMod, Soun);

        FindObjectOfType<StatTracker>().GetComponent<StatTracker>().TPlusOne();
    }

    public void SwapGun()
    {
        GB.NewGun(GunSprite, FRate, Auto, Bullet, Ammo, GunMod, Soun);
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
            if (Replace == false && TM.currentAmount < TM.maxAmount)
            {
                for (int i = 0; i < GameObject.FindObjectsOfType<zcreenMark>().Length; i++)
                {
                    GameObject.FindObjectsOfType<zcreenMark>()[i].GetComponent<zcreenMark>().turnOn();
                    //print("dadasasdsadasddqwe12312321321321312321321343543654767870");
                }
            }           

            other.gameObject.GetComponent<PlayerHealth>().PlayerHeal(3);

            transform.parent = null;

            //other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //Invoke("newStuff", 0.007f);

            if (Replace == true)
            {
                newStuff();
            }
            else
            {
                Invoke("newStuff", 0.017f);
                print("egor");
            }
            


            /*Destroy(gameObject);
            if (TM.currentAmount < TM.maxAmount)
            {
                //Destroy(gameObject);
                if (Replace == false)
                {
                    
                    MakeAnew();
                } else
                {
                    SwapGun();
                    for (int i = 0; i < GameObject.FindObjectsOfType<zcreenMark>().Length; i++)
                    {                       
                       // GameObject.FindObjectsOfType<zcreenMark>()[i].GetComponent<zcreenMark>().turnOFf();
                    }
                }
                
            } else
            {
                //Destroy(gameObject);

                SwapGun();
                for (int i = 0; i < GameObject.FindObjectsOfType<zcreenMark>().Length; i++)
                {
                   // GameObject.FindObjectsOfType<zcreenMark>()[i].GetComponent<zcreenMark>().turnOFf();
                }
            }*/


            //other.gameObject.GetComponent<PlayerHealth>().PlayerHeal(3);
           // other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }

        
        //MakeAnew();
        //print("dsad");
    }

    public void newStuff()
    {
        Destroy(gameObject);
        if (TM.currentAmount < TM.maxAmount)
        {
            //Destroy(gameObject);
            if (Replace == false)
            {
                MakeAnew();
            }
            else
            {
                SwapGun();                
            }

        }
        else
        {
            //Destroy(gameObject);

            SwapGun();         
        }
    }
}
