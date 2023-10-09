using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float currentHealth = 1;
    private float maxHealth;

    public bool dead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyHurt(float dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            death();
        }
    }

    public void EnemyHeal(float helt)
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

        //temp
        Destroy(gameObject);
    }
}
