using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDoorManager : MonoBehaviour
{
    //public GameObject Destroyed, maked;

    public float amount, a2, timer = 1;
    private TimelineManager Tm;
    // Start is called before the first frame update
    void Start()
    {
        Tm = FindObjectOfType<TimelineManager>();
    }

    // Update is called once per frame
    void Update()
    {
        a2 = FindObjectsOfType<TimeButton>().Length;

        //amount = FindObjectsOfType<TimeButton>()[FindObjectsOfType<TimeButton>().Length].GetComponent<TimeButton>().p2 == true;
        amount = FindObjectsOfType<POINT>().Length;

        if (amount == Tm.currentAmount && timer >= 1)
        {
            for (int i = 0; i < FindObjectsOfType<TimeButton>().Length; i++)
            {
                FindObjectsOfType<TimeButton>()[i].GetComponent<TimeButton>().doIt();
            }
            timer = 0;
        }

        if (timer < 1)
        {
            timer += 0.1f;
        }
    }
}
