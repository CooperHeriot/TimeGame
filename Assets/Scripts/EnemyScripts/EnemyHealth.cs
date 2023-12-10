using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float currentHealth = 1;
    private float maxHealth;

    public bool dead;

    public GameObject drop;

    private EnemyShoot ES;
    // Start is called before the first frame update
    void Start()
    {
        ES = GetComponent<EnemyShoot>();
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
        ES.Timeline.GetComponent<WaveBehaviour>().EnemyDie(gameObject);

        if (drop != null)
        {
            Instantiate(drop, transform.position, transform.rotation, transform.parent);
        }

        FindObjectOfType<StatTracker>().GetComponent<StatTracker>().KilledPlusOne();
        Destroy(gameObject);
    }
}
