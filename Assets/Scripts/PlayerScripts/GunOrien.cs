using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunOrien : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NewPos(PlayerPrefs.GetFloat("rien"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewPos(float _pos)
    {
        transform.localPosition = new Vector3(_pos, transform.localPosition.y, transform.localPosition.z);
    }
}
