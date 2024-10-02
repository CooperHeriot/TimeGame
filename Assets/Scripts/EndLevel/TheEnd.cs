using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnd : MonoBehaviour
{
    public GameObject Player;

    public GameObject endingg;
    // Start is called before the first frame update
    void Start()
    {
        
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

            Player.GetComponent<PlayerMove>().speed = 0;
            Player.GetComponent<PlayerMove>().turnSpeed = 0;
            Player.transform.GetChild(0).GetComponent<CamMove>().turnSpeed = 0;

            endingg.SetActive(true);

            endingg.transform.parent.transform.GetComponent<StatTracker>().done = true;

            //FindObjectOfType<StatTracker>().GetComponent<StatTracker>().done = true;
        }
    }
}
