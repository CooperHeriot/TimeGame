using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveableObject : MonoBehaviour
{
    public MouseData MyData = new MouseData();
    // Start is called before the first frame update
    void Awake()
    {
        UpdatemyData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatemyData()
    {
        if (GetComponent<PauseSensitivity>() != null)
        {
            MyData.theSensitivity = GetComponent<PauseSensitivity>().sensitibty;
        }
    }
    public void RestoreFromData()
    {
        if (GetComponent<PauseSensitivity>() != null)
        {
            GetComponent<PauseSensitivity>().sensitibty = MyData.theSensitivity;
        }
    }
}

[System.Serializable]

public class MouseData
{
    public float theSensitivity;

    public GameObject myObject;
}
