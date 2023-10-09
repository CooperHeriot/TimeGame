using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public float damage = 1;
    public bool HurtPlayer, HurtEnemy, destroyOnHit = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealth>() != null && HurtPlayer == true)
        {
            collision.gameObject.GetComponent<PlayerHealth>().PlayerHurt(damage);

            if (destroyOnHit == true)
            {
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.GetComponent<EnemyHealth>() != null && HurtEnemy == true)
        {
            collision.gameObject.GetComponent<EnemyHealth>().EnemyHurt(damage);

            if (destroyOnHit == true)
            {
                Destroy(gameObject);
            }
        }

        
       
    }
}
