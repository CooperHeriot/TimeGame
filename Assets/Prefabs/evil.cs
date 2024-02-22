using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evil : MonoBehaviour
{
    public GameObject cube;
    public Material cubeM;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < GameObject.FindObjectsOfType<Renderer>().Length; i++)
        {
            GameObject.FindObjectsOfType<Renderer>()[i].material = cubeM;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
