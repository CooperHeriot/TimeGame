using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Side{
    Left, Right, Middle
}

public class camSide : MonoBehaviour
{
    public Side side;

    public TimelineBehav TB;
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
        //side = Side.Left;
        TB.left();
    }

    public void right()
    {
        //side = Side.Right;
        TB.right();
    }

    public void iddle()
    {
        //side = Side.Middle;
        TB.iddle();
    }
}
