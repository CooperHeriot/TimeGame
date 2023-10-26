using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSensitivity : MonoBehaviour
{
    /* public CamMove CM;
     public PlayerMove PM;*/
    private TimelineManager TM;

    private float sensitibty;

   /* public List<CamMove> CM = new List<CamMove>();

    public List<PlayerMove> PM = new List<PlayerMove>();*/
    // Start is called before the first frame update
    void Start()
    {
        TM = FindObjectOfType<TimelineManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //CM = FindObjectsOfType<CamMove>();

        /*if (Input.GetKeyDown(KeyCode.K))
        {
            newSens(60);
        }*/
    }

    public void newSens(float sens)
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
    }

  
}
