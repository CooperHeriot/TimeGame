using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDoorManager : MonoBehaviour
{
    public GameObject Destroyed, maked;

    public float amount, a2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        a2 = FindObjectsOfType<TimeButton>().Length;

    }
}
