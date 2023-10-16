using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    private TimelineManager TM;

    //private List<GameObject> snes = new List<GameObject>();
    public List<Camera> Cams = new List<Camera>();

    public float Aount = 1;
    // Start is called before the first frame update
    void Start()
    {
        TM = GetComponent<TimelineManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TM.currentAmount == 1 && Aount != 1)
        {
            Cams[0].rect = new Rect(0.2f, 0f, 0.6f, 1f);
            Aount = 1;

            /*if (Cams[0].gameObject.GetComponentInChildren<Camera>() != null)
            {
                Cams[0].GetComponentInChildren<Camera>().rect = Cams[0].rect;
            }*/
        }

        if (TM.currentAmount == 2 && Aount != 2)
        {
            Cams[0].rect = new Rect(0.08f, 0.15f, 0.42f, 0.7f);
            Cams[1].rect = new Rect(0.5f, 0.15f, 0.42f, 0.7f);

            Aount = 2;
           
        }

        if (TM.currentAmount == 3 && Aount != 3)
        {
            Cams[0].rect = new Rect(0.35f, 0f, 0.3f, 0.5f);            
            Cams[1].rect = new Rect(0.2f, 0.5f, 0.3f, 0.5f);            
            Cams[2].rect = new Rect(0.5f, 0.5f, 0.3f, 0.5f);            

            Aount = 3;
            
        }

        if (TM.currentAmount == 4 && Aount != 4)
        {
            Cams[0].rect = new Rect(0.2f, 0f, 0.3f, 0.5f);
            Cams[1].rect = new Rect(0.5f, 0f, 0.3f, 0.5f);
            Cams[2].rect = new Rect(0.2f, 0.5f, 0.3f, 0.5f);
            Cams[3].rect = new Rect(0.5f, 0.5f, 0.3f, 0.5f);
            

            Aount = 4;
            
        }
    }
}
