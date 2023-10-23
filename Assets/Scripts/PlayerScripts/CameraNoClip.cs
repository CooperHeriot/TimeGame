using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNoClip : MonoBehaviour
{
    public GameObject Cam, basePos, basePoint;
    public LayerMask LM;
    public float dist;
    // Start is called before the first frame update
    void Start()
    {
        basePos.transform.position = Cam.transform.position;

        dist = Vector3.Distance(Cam.transform.position, basePoint.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(basePoint.transform.position, basePoint.transform.forward * -1, out hit, dist, LM))
        {
            Cam.transform.position = hit.point;
        } else
        {
            Cam.transform.position = basePos.transform.position;
        }
    }
}
