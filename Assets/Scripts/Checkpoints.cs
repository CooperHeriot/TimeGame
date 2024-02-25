using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public int points;
    public GameObject[] pointss;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("point");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
