using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimeButton : MonoBehaviour
{
    public GameObject Destroyed, maked, POINT;

    public float Powered;

    public bool p2;

    public GameObject Player;

    public float tier;
    // Start is called before the first frame update
    void Start()
    {
        POINT.SetActive(false);
        maked.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMove>() != null)
        {
            Player = other.gameObject;

            Player.GetComponent<PlayerMove>().stopped = true;
            Player.GetComponent<Rigidbody>().isKinematic = true;

            Powered = 1;

            p2 = true;

            POINT.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMove>() != null)
        {
            Player.GetComponent<PlayerMove>().stopped = false;
            Player.GetComponent<Rigidbody>().isKinematic = false;

            Powered = 0;

            p2 = false;

            POINT.SetActive(false);
        }
    }

    public void doIt()
    {
        if (tier <= 0)
        {
            Player.GetComponent<PlayerMove>().stopped = false;
            Player.GetComponent<Rigidbody>().isKinematic = false;

            Destroy(Destroyed);
            maked.SetActive(true);
        } else
        {
            tier -= 1;
        }
        
    }
}
