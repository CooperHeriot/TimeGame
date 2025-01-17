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

    public Renderer rend;
    private Color col;

    public ActivateRagdoll AR;

    public AudioClip hurt, dye;
    private TimelineBehav TB;
    // Start is called before the first frame update
    void Start()
    {
        ES = GetComponent<EnemyShoot>();

        oncce = false;

        col = rend.material.color;

        TB = ES.Timeline.GetComponent<TimelineBehav>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyHurt(float dmg)
    {
        currentHealth -= dmg;

        if (rend != null)
        {
            //col = rend.material.color;
            rend.material.color = Color.white;
            Invoke("returncol", 0.1f);
        }

        if (currentHealth <= 0)
        {
            honor = true;
            TB.GetComponent<AudioBehav>().PlaySound(dye);
            death();
        }

        TB.GetComponent<AudioBehav>().PlaySound(hurt);
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
        if (AR != null)
        {
            AR.TurnOnStuff();
            AR.transform.parent = null;
        }
        
        if (dead == false)
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
        }
        
        Destroy(gameObject);
    }

    public void returncol()
    {
        rend.material.color = col;
    }
}
