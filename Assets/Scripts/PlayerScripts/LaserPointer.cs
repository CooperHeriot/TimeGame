using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    public GameObject Mark, firepoint;

    public LayerMask LM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(firepoint.transform.position, firepoint.transform.forward, out hit, 80, LM))
        {

            Mark.SetActive(true);

            Mark.transform.position = hit.point;
           /// Mark.transform.position = Vector3.Slerp(Mark.transform.position, hit.point, 10 * Time.deltaTime);
        } else
        {
            Mark.SetActive(false);
        }
    }
}
