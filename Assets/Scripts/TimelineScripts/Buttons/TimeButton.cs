using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeButton : MonoBehaviour
{
    public GameObject Destroyed, maked, POINT;

    public float Powered;

    public bool p2;
    // Start is called before the first frame update
    void Start()
    {
        POINT.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMove>() != null)
        {
            Powered = 1;

            p2 = true;

            POINT.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMove>() != null)
        {
            Powered = 0;

            p2 = false;

            POINT.SetActive(false);
        }
    }

    public void doIt()
    {
        Destroy(Destroyed);
        maked.SetActive(true);
    }
}
