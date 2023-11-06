using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHolder : MonoBehaviour
{
    private TimelineManager TM;

    public float sensitibty;

    public GameObject PH;

    // Start is called before the first frame update
    void Start()
    {
        TM = FindObjectOfType<TimelineManager>();

        //ps = PH.GetComponent<PauseHolder>();
    }

    void Awake()
    {
        PH = FindObjectOfType<PauseSensitivity>().gameObject;

        newrSens(PH.GetComponent<PauseSensitivity>().sensitibty);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void newrSens(float _new)
    {
        sensitibty = _new;

        for (int i = 0; i < FindObjectsOfType<CamMove>().Length; i++)
        {
            FindObjectsOfType<CamMove>()[i].GetComponent<CamMove>().turnSpeed = sensitibty;
        }
        for (int i = 0; i < FindObjectsOfType<PlayerMove>().Length; i++)
        {
            FindObjectsOfType<PlayerMove>()[i].GetComponent<PlayerMove>().turnSpeed = sensitibty;
        }

        FindObjectOfType<PauseSensitivity>().sensitibty = sensitibty;
    }
}

