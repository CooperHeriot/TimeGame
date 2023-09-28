using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineBehav : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void becomePrime()
    {
        Player.GetComponent<Gunbehav>().Prime = true;
    }
}
