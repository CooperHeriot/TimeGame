using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;
using UnityEngine.UIElements;

public class PauseSensitivity : MonoBehaviour
{
    /* public CamMove CM;
     public PlayerMove PM;*/
    private TimelineManager TM;

    public float sensitibty, sens2;

    public GameObject PH;
    private PauseHolder ps;
    public float adada = 0.1f;
    public bool trigged;

    public float asfsd;
   /* public List<CamMove> CM = new List<CamMove>();

    public List<PlayerMove> PM = new List<PlayerMove>();*/
    // Start is called before the first frame update
    void Start()
    {
        sensitibty = PlayerPrefs.GetFloat("senss");

        TM = FindObjectOfType<TimelineManager>();

        //ps = PH.GetComponent<PauseHolder>();
        sens2 = sensitibty;
    }

    /*void Awake()
    {
        asfsd = Random.Range(1, 10);

        trigged = true;
        // print("ghjkjertyutre");
        //slidee = GameObject.Find("Sensitivity");

        //slidee.GetComponent<Slider>().
        //PH = GameObject.Find("ChangeSensitivity");
        PH = FindObjectOfType<PauseHolder>().gameObject;
        ps = PH.GetComponent<PauseHolder>();

        ps.PH = gameObject;

        //ps.sensitibty = sensitibty;
    }*/


    // Update is called once per frame
    void Update()
    {

        if(sensitibty != sens2)
        {
            UpdateSave();
            sens2 = sensitibty;
        }
        //CM = FindObjectsOfType<CamMove>();

        /*if (Input.GetKeyDown(KeyCode.K))
        {
            newSens(60);
        }*/
        //slidee = GameObject.Find("Sensitivity");
        /*if (trigged == true)
        {
            adada -= 0.05f * Time.deltaTime;
        }
        if (adada <= 0)
        {
            trigged = false;
            adada = 0.1f;

            PH = FindObjectOfType<PauseHolder>().gameObject;
            ps = PH.GetComponent<PauseHolder>();

            ps.PH = gameObject;

            ps.newrSens(sensitibty);
        }*/
    }

   /* public void newSens(float sens)
    {
        sensitibty = sens;

        for (int i = 0; i < FindObjectsOfType<CamMove>().Length; i++)
        {
            FindObjectsOfType<CamMove>()[i].GetComponent<CamMove>().turnSpeed = sensitibty;
        }
        for (int i = 0; i < FindObjectsOfType<PlayerMove>().Length; i++)
        {
            FindObjectsOfType<PlayerMove>()[i].GetComponent<PlayerMove>().turnSpeed = sensitibty;
        }
    } */

    

  public void UpdateSave()
    {
        GetComponent<SaveableObject>().UpdatemyData();
    }
}
