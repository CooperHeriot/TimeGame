using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieTimer : MonoBehaviour
{
    public float timer = 1;
    public GameObject particl;
    // Update is called once per frame
    void Update()
    {
        timer -= 1 * Time.deltaTime;

        if (timer <= 0)
        {
            deth();
        }
    }

    public void deth()
    {
        if (particl != null)
        {
            Instantiate(particl, transform.position, transform.rotation);
        }

        Destroy(gameObject);
    }
}
