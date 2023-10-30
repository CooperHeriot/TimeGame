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
    // Start is called before the first frame update
    void Start()
    {
        TM = FindObjectOfType<TimelineManager>();

        Paus = GetComponent<Pause>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //currentTime = Mathf.Lerp(currentTime, GoalTime, speed * Time.deltaTime);
            currentTime = GoalTime;
        } else
        {
            //currentTime = Mathf.Lerp(currentTime, 1, 4 * speed * Time.deltaTime);
            currentTime = 1;
        }

        Paus.TheTime = currentTime;
    }
}
