using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public bool ded, stopped;
    public bool grounded;

    public float speed = 1, jump = 1;
    private Rigidbody rb;
    public LayerMask LM;

    [Header("Enable first person mode")]
    public bool FPSMode;
    public float turnSpeed;

    public TimeSlow TS;
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
            /*Vector3 forwardVector = transform.forward * Input.GetAxis("Vertical");
            Vector3 sideVector = transform.right * Input.GetAxis("Horizontal");
            Vector3 movementVector = (forwardVector + sideVector).normalized;

            rb.velocity = movementVector * speed + Vector3.up * rb.velocity.y;

            transform.Rotate(0, Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime, 0);*/
        }
              
    }

    void Update()
    {
        if (FPSMode == true)
        {
            Vector3 forwardVector = transform.forward * Input.GetAxis("Vertical");
            Vector3 sideVector = transform.right * Input.GetAxis("Horizontal");
            Vector3 movementVector = (forwardVector + sideVector).normalized;

            if (ded == false && stopped == false)
            {
                rb.velocity = movementVector * speed + Vector3.up * rb.velocity.y;
            }

            if (Time.timeScale > 0) {
                //transform.Rotate(0, (Input.GetAxis("Mouse X") * turnSpeed) * Time.deltaTime, 0);
                transform.Rotate(0, (Input.GetAxis("Mouse X") * turnSpeed), 0);

                if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
                {
                    rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
                }
            }
        }

        if (Physics.Raycast(transform.position, -transform.up, 1.6f, LM))
        {
            grounded = true;
        } else { 
        grounded = false;
        }
    }
}
