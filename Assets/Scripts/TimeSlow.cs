using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlow : MonoBehaviour
{
    public float currentTime, GoalTime;
    public float speed = 1;

    public float TimeJuice;
    private TimelineManager TM;
    private Pause Paus;

    private float TJ;
    // Start is called before the first frame update
    void Start()
    {
        TM = FindObjectOfType<TimelineManager>();

        Paus = GetComponent<Pause>();

        TJ = TimeJuice;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && TimeJuice > 0)
        {
            currentTime = Mathf.Lerp(currentTime, GoalTime, speed * Time.deltaTime);
            //currentTime = GoalTime;

            TimeJuice -= 1;
        } else
        {
            currentTime = Mathf.Lerp(currentTime, 1, 4 * speed * Time.deltaTime);
            //currentTime = 1;

            if (TM.currentAmount > 1)
            {
                TimeJuice += (1 * TM.currentAmount);
            }

        }

        if (TimeJuice > TJ)
        {
            TimeJuice = TJ;
        }

        Paus.TheTime = currentTime;
    }
}
