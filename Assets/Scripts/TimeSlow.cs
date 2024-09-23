using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class TimeSlow : MonoBehaviour
{
    public bool notFirst;
    public float currentTime, GoalTime;
    public float currentRot, GoalRot;
    public float speed = 1;

    public float TimeJuice;
    private TimelineManager TM;
    private Pause Paus;

    public float TJ;

    public Image img;
    public GameObject reminder;
    public GameObject explain;
    public bool actinaetd;
    //public GameObject ehgh;

    public bool slowing;
    public Volume Vol;
    private ColorAdjustments CA;
    private Bloom BL;
    // Start is called before the first frame update
    void Start()
    {
        reminder.SetActive(false);

        TM = FindObjectOfType<TimelineManager>();

        Paus = GetComponent<Pause>();

        TJ = TimeJuice;
        TimeJuice = 0;
        Vol.profile.TryGet(out CA);
        Vol.profile.TryGet(out BL);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && TimeJuice > 0)
        {
            slowing = true;
            notFirst = true;
            currentTime = Mathf.Lerp(currentTime, GoalTime, speed * Time.deltaTime);
            currentRot = Mathf.Lerp(currentRot, GoalRot, speed * Time.deltaTime);
            //currentTime = GoalTime;

            TimeJuice -= 2 * Time.deltaTime;

            if (reminder != null && reminder.activeSelf == true)
            {
                Destroy(reminder.gameObject);
            }

            CA.saturation.value = Mathf.Lerp(CA.saturation.value, -90, 3 * Time.deltaTime);
            BL.intensity.value = Mathf.Lerp(BL.intensity.value, 30, 3 * Time.deltaTime);
        } else
        {
            slowing = false;

            currentTime = Mathf.Lerp(currentTime, 1, 4 * speed * Time.deltaTime);
            currentRot = Mathf.Lerp(currentRot, 1, 4 * speed * Time.deltaTime);
            //currentTime = 1;

            if (TM != null)
            {
                if (TM.currentAmount > 1 && !Input.GetKey(KeyCode.LeftShift) && actinaetd == true)
                {
                    if (notFirst == false)
                    {
                        TimeJuice += ((0.75f * (TM.currentAmount - 1)) * Time.deltaTime);
                    } else
                    {
                        TimeJuice += ((0.25f * (TM.currentAmount - 1)) * Time.deltaTime);
                    }
                    
                }
            }
            CA.saturation.value = Mathf.Lerp(CA.saturation.value, 37, 5 * Time.deltaTime);
            BL.intensity.value = Mathf.Lerp(BL.intensity.value, 4.87f, 5 * Time.deltaTime);
        }

        if (TimeJuice > TJ)
        {
            TimeJuice = TJ;
            notFirst = true;

            if (reminder != null && explain.activeInHierarchy == true)
            {
                reminder.SetActive(true);
                explain.SetActive(false);
            }            
        }

        Paus.TheTime = currentTime;

        img.fillAmount = (TimeJuice / TJ);
    }

    public void acriakavted()
    {
        actinaetd = true;
    }
}
