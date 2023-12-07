using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth = 3;
    public float maxHealth;

    public bool dead;
    private PlayerMove PM;
    public GameObject damageBorder, heltBorder;

    public TimeDeleteTest TDT;
    public float IFrames = 1;
    public float IFFrames;
    // Start is called before the first frame update
    void Start()
    {
        PM = GetComponent<PlayerMove>();
        damageBorder.SetActive(false);
        heltBorder.SetActive(false);

        if (maxHealth == 0)
        {
            maxHealth = currentHealth;
        }

        if (IFFrames == 0)
        {
            //IFFrames = IFrames;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerHurt(0);
        }*/
        if (IFrames > 0)
        {
            IFrames -= 1 * Time.deltaTime;
        }
    }

    public void PlayerHurt(float dmg)
    {
        if (IFrames <= 0)
        {
            currentHealth -= dmg;

            damageBorder.SetActive(false);
            damageBorder.SetActive(true);

            IFrames = IFFrames;

            if (currentHealth <= 0)
            {
                death();
            }
        }

        
    }

    public void PlayerHeal(float helt)
    {
        currentHealth += helt;

        heltBorder.SetActive(false);
        heltBorder.SetActive(true);

        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void death()
    {
        dead = true;
        PM.ded = true;

        for (int i = 0; i < FindObjectsOfType<PlayerHealth>().Length; i++)
        {
            FindObjectsOfType<PlayerHealth>()[i].GetComponent<PlayerHealth>().IFrames = IFFrames;
        }

        TDT.kill = true;
    }
}
