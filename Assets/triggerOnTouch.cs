using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerOnTouch : MonoBehaviour
{
    public bool Destroyy;
    public GameObject theThing;
    // Start is called before the first frame update
    void Start()
    {
        if (Destroyy == false)
        {
            theThing.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMove>() != null)
        {
            theThing.SetActive(true);
            if (Destroyy == true)
            {
                Destroy(theThing);
            }

            Destroy(gameObject);
        }
    }
}
