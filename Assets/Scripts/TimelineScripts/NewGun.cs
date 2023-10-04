using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGun : MonoBehaviour
{
    public GameObject ThisTimeLine;

    private TimelineManager TM;
    // Start is called before the first frame update
    void Start()
    {
        TM = FindObjectOfType<TimelineManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            MakeAnew();
        }
    }

    public void MakeAnew()
    {
        TM.createNewTimeline(ThisTimeLine);
    }
}
