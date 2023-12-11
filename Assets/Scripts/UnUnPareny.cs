using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnUnPareny : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = transform.parent.gameObject.transform.parent;
    }
}
