using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth = 3;
    public float maxHealth;

    public bool dead;
    private PlayerMove PM;
    public GameObject damageBorder;

    public TimeDeleteTest TDT;
    // Start is called before the first frame update
    void Start()
    {
        PM = GetComponent<PlayerMove>();
        damageBorder.SetActive(false);

        if (maxHealth == 0)
        {
            maxHealth = currentHealth;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerHurt(0);
        }*/
    }

    public void PlayerHurt(float dmg)
    {
        currentHealth -= dmg;

        damageBorder.SetActive(false);
        damageBorder.SetActive(true);

        if (currentHealth <= 0)
        {
            death();
        }
    }

    public void PlayerHeal(float helt)
    {
        currentHealth += helt;

        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void death()
    {
        dead = true;
        PM.ded = true;

        TDT.kill = true;
    }
}
