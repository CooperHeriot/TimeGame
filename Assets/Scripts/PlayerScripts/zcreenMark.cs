using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zcreenMark : MonoBehaviour
{
    public Rigidbody rb;
    public bool tinger;
    public float tim = 0.006f;
    public float tim2;
    // Start is called before the first frame update
    void Start()
    {
        tim2 = tim;
    }

    // Update is called once per frame
    void Update()
    {
        if (tinger == true)
        {
            tim -= 1 * Time.deltaTime;
        }

        if  (tim <= 0)
        {
            turnOFf();
            tinger = false;
            tim = tim2;
        }
    }

    public void turnOn()
    {
        rb.isKinematic = true;

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).transform.gameObject.SetActive(true);
        }

        tinger = true;
        //Invoke("turnOFf", 0.006f);
    }

    public void turnOFf()
    {
        rb.isKinematic = false;

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).transform.gameObject.SetActive(false);
        }
    }
}
