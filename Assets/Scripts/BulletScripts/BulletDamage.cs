using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public float damage = 1;
    public bool HurtPlayer, HurtEnemy, destroyOnHit = true;

    public bool knockBack;
    public bool BreaksWalls;
    private bool solid;
    // Start is called before the first frame update
    void Start()
    {
       /* if (GetComponent<SphereCollider>().isTrigger == false)
        {
            solid = false;
        } else
        {
            solid = true;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealth>() != null && HurtPlayer == true)
        {
            collision.gameObject.GetComponent<PlayerHealth>().PlayerHurt(1);

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

        if (knockBack == true && collision.gameObject.GetComponent<Rigidbody>() != null)
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce((collision.gameObject.transform.position - transform.position) * damage * 100);
        }

        if (collision.transform.tag == "Destroyable")
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealth>() != null && HurtPlayer == true)
        {
            collision.gameObject.GetComponent<PlayerHealth>().PlayerHurt(1);

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

        if (knockBack == true && collision.gameObject.GetComponent<Rigidbody>() != null)
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce((collision.gameObject.transform.position - transform.position) * damage * 100);
        }

        if (collision.transform.tag == "Destroyable")
        {
            Destroy(collision.gameObject);
        }
    }
}
