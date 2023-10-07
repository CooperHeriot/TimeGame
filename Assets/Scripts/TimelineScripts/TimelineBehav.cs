using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineBehav : MonoBehaviour
{
    private TimelineManager TM;

    public GameObject Player;
    private Gunbehav GB;

    public Quaternion PrimeRot, notPrimeRot;

    [Header("is this Prime")]
    public bool prime;
    public GameObject PrimeBorder;

    [Header("Camera")]
    public Camera Cam;
    // Start is called before the first frame update
    void Start()
    {
        TM = FindObjectOfType<TimelineManager>();

        GB = Player.GetComponent<Gunbehav>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //get rotation of prime player
        if (prime == true)
        {
            PrimeRot = GB.Model.transform.rotation;

            TM.primmeRot = PrimeRot;

            GB.Prime = true;
        } else
        {
            GB.Prime = false;

            PrimeBorder.SetActive(false);
        }

        //rotate the non prime players
        notPrimeRot = TM.primmeRot;
        if (GB.Prime == false)
        {
            
            GB.Model.transform.rotation = notPrimeRot;
        }
    }

    public void becomePrime()
    {
        prime = true;

        Player.GetComponent<Gunbehav>().Prime = true;

        PrimeBorder.SetActive(true);
    }
}
