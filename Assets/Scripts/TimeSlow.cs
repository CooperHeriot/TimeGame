using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSlow : MonoBehaviour
{
    public float currentTime, GoalTime;
    public float speed = 1;

    public float TimeJuice;
    private TimelineManager TM;
    private Pause Paus;

    public float TJ;

    public Image img;
    public GameObject reminder;
    // Start is called before the first frame update
    void Start()
    {
        reminder.SetActive(false);

        TM = FindObjectOfType<TimelineManager>();

        Paus = GetComponent<Pause>();

        TJ = TimeJuice;
        TimeJuice = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && TimeJuice > 0)
        {
            currentTime = Mathf.Lerp(currentTime, GoalTime, speed * Time.deltaTime);
            //currentTime = GoalTime;

            TimeJuice -= 2 * Time.deltaTime;

            if (reminder != null)
            {
                Destroy(reminder.gameObject);
            }
        } else
        {
            currentTime = Mathf.Lerp(currentTime, 1, 4 * speed * Time.deltaTime);
            //currentTime = 1;

            if (TM.currentAmount > 1)
            {
                TimeJuice += ((0.25f * (TM.currentAmount - 1)) * Time.deltaTime);
            }

        }

        if (TimeJuice > TJ)
        {
            TimeJuice = TJ;

            if (reminder != null)
            {
                reminder.SetActive(true);
            }            
        }

        Paus.TheTime = currentTime;

        img.fillAmount = (TimeJuice / TJ);
    }
}
