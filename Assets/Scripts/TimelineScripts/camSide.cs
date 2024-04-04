using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Side{
    Left, Right, Middle
}

public class camSide : MonoBehaviour
{
    public Side side;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void left()
    {
        side = Side.Left;
    }

    public void right()
    {
        side = Side.Right;
    }

    public void iddle()
    {
        side = Side.Middle;
    }
}
