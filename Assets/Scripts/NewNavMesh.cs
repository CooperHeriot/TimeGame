using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;

public class NewNavMesh : MonoBehaviour
{
    public NavMeshSurface NV;
    // Start is called before the first frame update
    void Start()
    {

    }
    //this Script is more of a navmesh manager

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.I))
        {
            makeNew();
        }*/
    }

    public void makeNew()
    {
        NV.BuildNavMesh();
    }
}
