using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHoleSnap : MonoBehaviour
{
    public LayerMask LM;

    // Start is called before the first frame update
    void Start()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward * -1, out hit, 1, LM))
        {
            transform.position = hit.point;
            //transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);

            transform.parent = hit.transform;
        } else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
