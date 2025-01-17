using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Tier;

    public bool ded, stopped;
    public bool grounded;

    public float speed = 1, jump = 1, pulldown = 1;
    private Rigidbody rb;
    public LayerMask LM;

    [Header("Enable first person mode")]
    public bool FPSMode;
    public float turnSpeed;

    public TimeSlow TS;

    public GameObject tiltOBJ;
    public Vector3 zzzzd;
    public float z2;
    private int Inv;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.isKinematic = false;
        turnSpeed = PlayerPrefs.GetFloat("senss");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Inv = PlayerPrefs.GetInt("Inverty");
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

        if (grounded == false && (Input.GetKey(KeyCode.Space) == false || rb.velocity.y < 0))
        {
            rb.AddForce(0, -pulldown * Time.deltaTime, 0);          
        }
    }

    void Update()
    {
        if (FPSMode == true)
        {
            Vector3 forwardVector = transform.forward * Input.GetAxis("Vertical");
            Vector3 sideVector = transform.right * Input.GetAxis("Horizontal");
            Vector3 movementVector = (forwardVector + sideVector).normalized;

            //zzzzd = tiltOBJ.transform.right * Input.GetAxis("Horizontal"); ;

            if (ded == false && stopped == false)
            {
                if (grounded == true || TS.slowing == true)
                {
                    rb.velocity = movementVector * speed + Vector3.up * rb.velocity.y;
                } else
                {
                    rb.AddForce((movementVector * speed) / 3);
                }               
            }

            if (Time.timeScale > 0) {
                //transform.Rotate(0, (Input.GetAxis("Mouse X") * turnSpeed) * Time.deltaTime, 0);
                transform.Rotate(0, (Input.GetAxis("Mouse X") * (turnSpeed * Inv)), 0);

                if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
                {
                    rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
                }
            }
        }

        //z2 = (Input.GetAxis("Horizontal") * -1) / 100;
        //z2 = (Input.GetAxis("Horizontal") * -1) / 25;
        z2 = Mathf.Lerp(z2, (Input.GetAxis("Horizontal") * -1) / 40, 15 * Time.deltaTime);

        tiltOBJ.transform.localRotation = new Quaternion(0, 0, z2, tiltOBJ.transform.localRotation.w);

        if (Physics.Raycast(transform.position, -transform.up, 1.6f, LM))
        {
            grounded = true;
        } else { 
        grounded = false;
        }
    }

    private void OnEnable()
    {
        turnSpeed = PlayerPrefs.GetFloat("senss");
    }
}
