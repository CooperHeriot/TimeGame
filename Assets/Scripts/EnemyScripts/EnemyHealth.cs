using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float currentHealth = 1;
    private float maxHealth;

    public bool dead;

    public GameObject drop;
    private bool oncce;

    private EnemyShoot ES;

    public bool inderpendat;
    private bool honor = false;
    // Start is called before the first frame update
    void Start()
    {
        ES = GetComponent<EnemyShoot>();

        oncce = false;
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
            honor = true;
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
        if (inderpendat == false)
        {
            ES.Timeline.GetComponent<WaveBehaviour>().EnemyDie(gameObject);
        }       

        if (drop != null && oncce == false)
        {
            Instantiate(drop, transform.position, transform.rotation, transform.parent);
            oncce = true;
        }
        if (honor == true)
        {
            FindObjectOfType<StatTracker>().GetComponent<StatTracker>().KilledPlusOne();
            FindObjectOfType<WaveManager>().GetComponent<WaveManager>().killss += 1;
        }       
        Destroy(gameObject);
    }
}
