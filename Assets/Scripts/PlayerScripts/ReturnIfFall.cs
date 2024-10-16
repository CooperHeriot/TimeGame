using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnIfFall : MonoBehaviour
{
    public Vector3 Point;
    private LayerMask LM;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        LM = GetComponent<PlayerMove>().LM;
        if (GetComponent<Rigidbody>() != null)
        {
            rb = GetComponent<Rigidbody>();
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, -transform.up, out hit, 1.6f, LM))
        {
            Point = hit.point;
        }

        if (transform.position.y < Point.y -20)
        {
            //transform.position = new Vector3(Point.x, Point.y + 2, Point.z);
            returnToFloor();
        }
    }

    public void returnToFloor()
    {
        transform.position = new Vector3(Point.x, Point.y + 2, Point.z);
        rb.velocity = Vector3.zero;
    }
}
