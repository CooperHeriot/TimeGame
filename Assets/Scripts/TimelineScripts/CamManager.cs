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

    public Rect C11Alt;
    public Rect C22Alt;

    [Header("3")]
    public Rect C111;
    public Rect C222;
    public Rect C333;

    public Rect C111Alt;
    public Rect C222Alt;
    public Rect C333Alt;

    [Header("4")]
    public Rect C1111;
    public Rect C2222;
    public Rect C3333;
    public Rect C4444;

    public Rect C1111Alt;
    public Rect C2222Alt;
    public Rect C3333Alt;
    public Rect C4444Alt;
    // Start is called before the first frame update
    void Start()
    {
        TM = GetComponent<TimelineManager>();

        if (PlayerPrefs.GetInt("Scren") == 1)
        {
            EnableFullScreen = true;
        }
        else
        {
            EnableFullScreen = false;
        }

        if (EnableFullScreen == false)
        {
            Cams[0].rect = C1;

            Cams[0].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.0274f, 0.96408f, 1f);
        }
        else
        {
            Cams[0].rect = C1Alt;

            Cams[0].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.75f, 0.96408f, 1f);
        }
        Cams[0].GetComponent<camSide>().iddle();

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

                Cams[0].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.0274f, 0.96408f, 1f);
            }
            else
            {
                Cams[0].rect = C1Alt;

                Cams[0].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.75f, 0.96408f, 1f);
            }
            Cams[0].GetComponent<camSide>().iddle();

            Aount = 1;
        }

        if (TM.currentAmount == 2 && Aount != 2)
        {
            //Cams[0].rect = new Rect(0.08f, 0.15f, 0.42f, 0.7f);
            //Cams[1].rect = new Rect(0.5f, 0.15f, 0.42f, 0.7f);
            if (EnableFullScreen == false)
            {
                Cams[0].rect = C11;
                Cams[1].rect = C22;

                Cams[0].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.0274f, 0.96408f, 1f);
                Cams[1].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.0274f, 0.96408f, 1f);
            }
            else
            {
                Cams[0].rect = C11Alt;
                Cams[1].rect = C22Alt;

                Cams[0].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(0.84f, 0.96408f, 1f);
                Cams[1].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(0.84f, 0.96408f, 1f);
            }
            Cams[0].GetComponent<camSide>().left();
            Cams[1].GetComponent<camSide>().right();

            Aount = 2; 

        }

        if (TM.currentAmount == 3 && Aount != 3)
        {
            //Cams[0].rect = new Rect(0.35f, 0f, 0.3f, 0.5f);            
            //Cams[1].rect = new Rect(0.2f, 0.5f, 0.3f, 0.5f);            
            //Cams[2].rect = new Rect(0.5f, 0.5f, 0.3f, 0.5f);
            if (EnableFullScreen == false)
            {
                Cams[0].rect = C111;
                Cams[1].rect = C222;
                Cams[2].rect = C333;

                Cams[0].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.0274f, 0.96408f, 1f);
                Cams[1].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.0274f, 0.96408f, 1f);
                Cams[2].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.0274f, 0.96408f, 1f);
            }
            else
            {
                Cams[0].rect = C111Alt;
                Cams[1].rect = C222Alt;
                Cams[2].rect = C333Alt;

                Cams[0].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.75f, 0.96408f, 1f);
                Cams[1].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.75f, 0.96408f, 1f);
                Cams[2].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.75f, 0.96408f, 1f);
            }
            Cams[0].GetComponent<camSide>().iddle();
            Cams[1].GetComponent<camSide>().left();
            Cams[2].GetComponent<camSide>().right();

            Aount = 3;            
        }

        if (TM.currentAmount == 4 && Aount != 4)
        {            
            if (EnableFullScreen == false)
            {
                Cams[0].rect = C1111;
                Cams[1].rect = C2222;
                Cams[2].rect = C3333;
                Cams[3].rect = C4444;

                Cams[0].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.0274f, 0.96408f, 1f);
                Cams[1].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.0274f, 0.96408f, 1f);
                Cams[2].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.0274f, 0.96408f, 1f);
                Cams[3].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.0274f, 0.96408f, 1f);
            }
            else
            {
                Cams[0].rect = C1111Alt;
                Cams[1].rect = C2222Alt;
                Cams[2].rect = C3333Alt;
                Cams[3].rect = C4444Alt;

                Cams[0].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.73f, 0.96408f, 1f);
                Cams[1].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.73f, 0.96408f, 1f);
                Cams[2].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.73f, 0.96408f, 1f);
                Cams[3].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.73f, 0.96408f, 1f);
            }
            Cams[0].GetComponent<camSide>().left();
            Cams[1].GetComponent<camSide>().right();
            Cams[2].GetComponent<camSide>().left();
            Cams[3].GetComponent<camSide>().right();

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
        EnableFullScreen = !EnableFullScreen;

        if (EnableFullScreen == true)
        {
            PlayerPrefs.SetInt("Scren", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Scren", 0);
        }

        if (TM.currentAmount == 1)
        {
            //Cams[0].rect = new Rect(0.2f, 0f, 0.6f, 1f);
            if (EnableFullScreen == false)
            {
                Cams[0].rect = C1;

                Cams[0].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.0274f, 0.96408f, 1f);
            }
            else
            {
                Cams[0].rect = C1Alt;

                Cams[0].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.75f, 0.96408f, 1f);
            }

            //Aount = 1; 
        }
        if (TM.currentAmount == 2)
        {
            //Cams[0].rect = new Rect(0.08f, 0.15f, 0.42f, 0.7f);
            //Cams[1].rect = new Rect(0.5f, 0.15f, 0.42f, 0.7f);
            if (EnableFullScreen == false)
            {
                Cams[0].rect = C11;
                Cams[1].rect = C22;

                Cams[0].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.0274f, 0.96408f, 1f);
                Cams[1].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.0274f, 0.96408f, 1f);
            }
            else
            {
                Cams[0].rect = C11Alt;
                Cams[1].rect = C22Alt;

                Cams[0].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(0.84f, 0.96408f, 1f);
                Cams[1].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(0.84f, 0.96408f, 1f);
            }
            //Aount = 2;
        }
        if (TM.currentAmount == 3)
        {
            if (EnableFullScreen == false)
            {
                Cams[0].rect = C111;
                Cams[1].rect = C222;
                Cams[2].rect = C333;

                Cams[0].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.0274f, 0.96408f, 1f);
                Cams[1].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.0274f, 0.96408f, 1f);
                Cams[2].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.0274f, 0.96408f, 1f);
            }
            else
            {
                Cams[0].rect = C111Alt;
                Cams[1].rect = C222Alt;
                Cams[2].rect = C333Alt;

                Cams[0].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.75f, 0.96408f, 1f);
                Cams[1].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.75f, 0.96408f, 1f);
                Cams[2].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.75f, 0.96408f, 1f);
            }
           // Aount = 3;
        }
        if (TM.currentAmount == 4)
        {
            if (EnableFullScreen == false)
            {
                Cams[0].rect = C1111;
                Cams[1].rect = C2222;
                Cams[2].rect = C3333;
                Cams[3].rect = C4444;

                Cams[0].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.0274f, 0.96408f, 1f);
                Cams[1].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.0274f, 0.96408f, 1f);
                Cams[2].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.0274f, 0.96408f, 1f);
                Cams[3].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.0274f, 0.96408f, 1f);
            }
            else
            {
                Cams[0].rect = C1111Alt;
                Cams[1].rect = C2222Alt;
                Cams[2].rect = C3333Alt;
                Cams[3].rect = C4444Alt;

                Cams[0].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.73f, 0.96408f, 1f);
                Cams[1].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.73f, 0.96408f, 1f);
                Cams[2].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.73f, 0.96408f, 1f);
                Cams[3].transform.GetChild(0).transform.GetChild(0).localScale = new Vector3(1.73f, 0.96408f, 1f);
            }
            //Aount = 4;
        }

        
    }
}
