using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool ded;

    public float speed = 1;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 MovementVector = new Vector3(x, 0, z).normalized;

        if (ded == false)
        {
            rb.velocity = (MovementVector * speed);
        }        
    }
}
