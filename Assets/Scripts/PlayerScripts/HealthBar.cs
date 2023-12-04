using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image bar;

    public PlayerHealth PH;

    public Color w1, w2, w3;

    public GameObject b1, b2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = (PH.currentHealth / PH.maxHealth);

        if (PH.currentHealth == 3)
        {
            bar.color = w3;

            for (int i = 0; i < b1.transform.childCount; i++)
            {
                if (b1.transform.GetChild(i).GetComponent<MeshRenderer>() != null)
                {
                    b1.transform.GetChild(i).GetComponent<MeshRenderer>().material.color = w3;
                }
            }
            for (int i = 0; i < b2.transform.childCount; i++)
            {
                if (b2.transform.GetChild(i).GetComponent<MeshRenderer>() != null)
                {
                    b2.transform.GetChild(i).GetComponent<MeshRenderer>().material.color = w3;
                }
            }
        }
        if (PH.currentHealth == 2)
        {
            bar.color = w2;

            for (int i = 0; i < b1.transform.childCount; i++)
            {
                if (b1.transform.GetChild(i).GetComponent<MeshRenderer>() != null)
                {
                    b1.transform.GetChild(i).GetComponent<MeshRenderer>().material.color = w2;
                }
            }
            for (int i = 0; i < b2.transform.childCount; i++)
            {
                if (b2.transform.GetChild(i).GetComponent<MeshRenderer>() != null)
                {
                    b2.transform.GetChild(i).GetComponent<MeshRenderer>().material.color = w2;
                }
            }
        }
        if (PH.currentHealth == 1)
        {
            bar.color = w1;

            for (int i = 0; i < b1.transform.childCount; i++)
            {
                if (b1.transform.GetChild(i).GetComponent<MeshRenderer>() != null)
                {
                    b1.transform.GetChild(i).GetComponent<MeshRenderer>().material.color = w1;
                }
            }
            for (int i = 0; i < b2.transform.childCount; i++)
            {
                if (b2.transform.GetChild(i).GetComponent<MeshRenderer>() != null)
                {
                    b2.transform.GetChild(i).GetComponent<MeshRenderer>().material.color = w1;
                }
            }
        }
    }
}
