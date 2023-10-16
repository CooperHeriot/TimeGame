using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyParentCam : MonoBehaviour
{
    public Camera cam;
    private Camera me;
    // Start is called before the first frame update
    void Start()
    {
        me = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        me.rect = cam.rect;
    }
}
