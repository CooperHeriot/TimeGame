using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDeleteTest : MonoBehaviour
{
    private TimelineManager TM;

    public bool kill;
    public GameObject father, dyeImg;
    // Start is called before the first frame update
    void Start()
    {
        TM = FindObjectOfType<TimelineManager>();

        father = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (kill == true)
        {
            dyeImg.SetActive(true);

            Invoke("DeleteTime", 0.01f);
        }
    }
    
    public void DeleteTime()
    {
        TM.eraseTimeline(father);
    }
}
