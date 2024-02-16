using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    private TimelineManager TM;

    //private List<GameObject> snes = new List<GameObject>();
    public List<Camera> Cams = new List<Camera>();
    public Pause PH;
    public TimeSlow TS;

    public float Aount = 1;

    [Header("Enable Full Screen")]
    public bool EnableFullScreen;

    [Header("1")]
    public Rect C1;
    public Rect C1Alt;

    [Header("2")]
    public Rect C11;
    public Rect C22;

    [Header("3")]
    public Rect C111;
    public Rect C222;
    public Rect C333;

    [Header("4")]
    public Rect C1111;
    public Rect C2222;
    public Rect C3333;
    public Rect C4444;
    // Start is called before the first frame update
    void Start()
    {
        TM = GetComponent<TimelineManager>();

        if (EnableFullScreen == false)
        {
            Cams[0].rect = C1;

            Cams[0].transform.GetChild(0).transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        else
        {
            Cams[0].rect = C1Alt;

            Cams[0].transform.GetChild(0).transform.localScale = new Vector3(0.16f, 0.1f, 0.1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (TM.currentAmount == 1 && Aount != 1)
        {
            //Cams[0].rect = new Rect(0.2f, 0f, 0.6f, 1f);
            if (EnableFullScreen == false)
            {
                Cams[0].rect = C1;

                Cams[0].transform.GetChild(0).transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }
            else
            {
                Cams[0].rect = C1Alt;

                Cams[0].transform.GetChild(0).transform.localScale = new Vector3(0.16f, 0.1f, 0.1f);
            }
            

            Aount = 1;

        }

        if (TM.currentAmount == 2 && Aount != 2)
        {
            //Cams[0].rect = new Rect(0.08f, 0.15f, 0.42f, 0.7f);
            //Cams[1].rect = new Rect(0.5f, 0.15f, 0.42f, 0.7f);
            Cams[0].rect = C11;
            Cams[1].rect = C22;

            Aount = 2;
           
        }

        if (TM.currentAmount == 3 && Aount != 3)
        {
            //Cams[0].rect = new Rect(0.35f, 0f, 0.3f, 0.5f);            
            //Cams[1].rect = new Rect(0.2f, 0.5f, 0.3f, 0.5f);            
            //Cams[2].rect = new Rect(0.5f, 0.5f, 0.3f, 0.5f);            
            Cams[0].rect = C111;
            Cams[1].rect = C222;
            Cams[2].rect = C333;

            Aount = 3;
            
        }

        if (TM.currentAmount == 4 && Aount != 4)
        {
            //Cams[0].rect = new Rect(0.2f, 0f, 0.3f, 0.5f);
            //Cams[1].rect = new Rect(0.5f, 0f, 0.3f, 0.5f);
            //Cams[2].rect = new Rect(0.2f, 0.5f, 0.3f, 0.5f);
            //Cams[3].rect = new Rect(0.5f, 0.5f, 0.3f, 0.5f);
            Cams[0].rect = C1111;
            Cams[1].rect = C2222;
            Cams[2].rect = C3333;
            Cams[3].rect = C4444;

            Aount = 4;
            
        }

        for (int i = 0; i < Cams.Count; i++)
        {
            Cams[i].fieldOfView = (70 / (PH.TheTime));
            if (Cams[i].fieldOfView > 100)
            {
                Cams[i].fieldOfView = 100;
            }
            if (Cams[i].fieldOfView < 70)
            {
                Cams[i].fieldOfView = 70;
            }

            if (TS.slowing == true)
            {
                Cams[i].GetComponent<CamParticles>().particle.SetActive(true);
            } else
            {
                Cams[i].GetComponent<CamParticles>().particle.SetActive(false);
            }
        }
    }

    public void ToggleFullscreen()
    {
        if (TM.currentAmount == 1 && Aount != 1)
        {
            //Cams[0].rect = new Rect(0.2f, 0f, 0.6f, 1f);
            if (EnableFullScreen == false)
            {
                Cams[0].rect = C1;

                Cams[0].transform.GetChild(0).transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }
            else
            {
                Cams[0].rect = C1Alt;

                Cams[0].transform.GetChild(0).transform.localScale = new Vector3(0.16f, 0.1f, 0.1f);
            }


            Aount = 1;

        }
    }
}
