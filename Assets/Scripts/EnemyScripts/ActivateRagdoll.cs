using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActivateRagdoll : MonoBehaviour
{
    public List<Rigidbody> Rbs = new List<Rigidbody>();
    public List<Collider> colliders = new List<Collider>();
    // Start is called before the first frame update
    void Start()
    {
        checkforRigids(gameObject);
        for (int i = 0; i < colliders.Count; i++)
        {
            colliders[i].enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkforRigids(GameObject _gam)
    {
        for (int i = 0; i < _gam.transform.childCount; i++)
        {
            print("checked child no:" + i);
            if (_gam.transform.GetChild(i).GetComponent<Rigidbody>() != null)
            {
                Rbs.Add(_gam.transform.GetChild(i).GetComponent<Rigidbody>());
                print("GotRigid");
            }
            if (_gam.transform.GetChild(i).GetComponent<Collider>() != null)
            {
                colliders.Add(_gam.transform.GetChild(i).gameObject.GetComponent<Collider>());
                print("GotColliderp");
            }

            if (_gam.transform.GetChild(i).childCount > 0)
            {
                for (int ii = 0; ii < _gam.transform.GetChild(i).childCount; ii++)
                {
                    print("Diving into" + _gam.transform.GetChild(ii).gameObject);
                    checkforRigids(_gam.transform.GetChild(ii).gameObject);
                }
            }
        }
    }
}
