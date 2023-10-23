using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image bar;

    public PlayerHealth PH;

    public Color w1, w2, w3;
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
        }
        if (PH.currentHealth == 2)
        {
            bar.color = w2;
        }
        if (PH.currentHealth == 1)
        {
            bar.color = w1;
        }
    }
}
