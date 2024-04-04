using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zcreenMark : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void turnOn()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).transform.gameObject.SetActive(true);
        }

        Invoke("turnOFf", 0.006f);
    }

    public void turnOFf()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).transform.gameObject.SetActive(false);
        }
    }
}
