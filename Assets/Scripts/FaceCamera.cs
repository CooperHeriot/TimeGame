using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    public Camera Camm;
    // Start is called before the first frame update
    void Start()
    {
        Camm = GetComponentInParent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
