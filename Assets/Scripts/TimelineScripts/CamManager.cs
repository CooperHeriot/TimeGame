using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    private TimelineManager TM;

    private List<GameObject> snes = new List<GameObject>();
    public List<Camera> Cams = new List<Camera>();
    // Start is called before the first frame update
    void Start()
    {
        TM = GetComponent<TimelineManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
