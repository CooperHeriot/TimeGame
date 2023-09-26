using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOnTouch : MonoBehaviour
{
    public GameObject particl;

    private void OnCollisionEnter(Collision collision)
    {
        if (particl != null)
        {
            Instantiate(particl, transform.position, Quaternion.LookRotation(collision.contacts[0].normal));
        }

        Destroy(gameObject);
    }

}
