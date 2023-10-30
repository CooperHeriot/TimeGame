using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRandomGun : MonoBehaviour
{
    public List<GameObject> Guns = new List<GameObject>();

    public int gug;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Guns.Add(transform.GetChild(i).gameObject);
        }

        gug = Random.Range(0,Guns.Count);

        Guns[gug].transform.GetComponent<NewGun>().ThisTimeLine = transform.parent.gameObject;
        Guns[gug].transform.parent = null;

        
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
