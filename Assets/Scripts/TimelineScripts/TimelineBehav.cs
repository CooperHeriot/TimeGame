using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TSide
{
    Left, Right, Middle
}

public class TimelineBehav : MonoBehaviour
{
    public List<GameObject> Dors = new List<GameObject>();

    private TimelineManager TM;

    public GameObject Player;
    private Gunbehav GB;

    public Quaternion PrimeRot, notPrimeRot;

    public GameObject SplitImage;

    [Header("is this Prime")]
    public bool prime;
    public GameObject PrimeBorder;

    [Header("Camera")]
    public Camera Cam;

    [Header("Odd Even")]
    public bool OnOff;

    public GameObject G1, G2;

    [Header("Odd Even")]
    public TSide side;
    public AudioBehav AB;
    // Start is called before the first frame update
    void Start()
    {
        TM = FindObjectOfType<TimelineManager>();

        GB = Player.GetComponent<Gunbehav>();

        if (OnOff == true)
        {
            if (G1 != null)
            {
                G1.SetActive(false);
            }
            if (G2 != null)
            {
                G2.SetActive(true);
            }
        } else
        {
            if (G1 != null)
            {
                G1.SetActive(true);
            }
            if (G2 != null)
            {
                G2.SetActive(false);
            }
        }

        //SplitImage.SetActive(false);
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

            //PrimeBorder.SetActive(false);
        }

        //rotate the non prime players
        notPrimeRot = TM.primmeRot;
        if (GB.Prime == false)
        {
            
            //GB.Model.transform.rotation = notPrimeRot;
        }
    }

    public void becomePrime()
    {
        prime = true;

        Player.GetComponent<Gunbehav>().Prime = true;

        PrimeBorder.SetActive(true);
    }

    public void newGunForPlayer(Sprite _Gunn, float _FRate, bool _Auto, GameObject _Bullet, float _ammo, GameObject _Modle, AudioClip _SX)
    {
        Player.GetComponent<Gunbehav>().NewGun(_Gunn, _FRate, _Auto, _Bullet, _ammo, _Modle, _SX);
    }

   public void activateImg()
    {
        //SplitImage.SetActive(true);

        Invoke("ImgOff", 1);
    }

    public void ImgOff()
    {
        //SplitImage.SetActive(false);
    }


    public void left()
    {
        side = TSide.Left;

        AB.AS.panStereo = -1;
    }

    public void right()
    {
        side = TSide.Right;

        AB.AS.panStereo = 1;
    }

    public void iddle()
    {
        side = TSide.Middle;

        AB.AS.panStereo = 0;
    }
}
