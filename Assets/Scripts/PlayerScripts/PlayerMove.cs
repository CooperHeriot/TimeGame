using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool ded, stopped;

    public float speed = 1;
    private Rigidbody rb;

    [Header("Enable first person mode")]
    public bool FPSMode;
    public float turnSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (FPSMode == false)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 MovementVector = new Vector3(x, 0, z).normalized;

            if (ded == false && stopped == false)
            {
                rb.velocity = (MovementVector * speed);
            }
        } else
        {
            Vector3 forwardVector = transform.forward * Input.GetAxis("Vertical");
            Vector3 sideVector = transform.right * Input.GetAxis("Horizontal");
            Vector3 movementVector = (forwardVector + sideVector).normalized;

            rb.velocity = movementVector * speed + Vector3.up * rb.velocity.y;

            transform.Rotate(0, Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime, 0);
        }
              
    }
}
