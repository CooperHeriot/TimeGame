using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActivateRagdoll : MonoBehaviour
{
    public List<Rigidbody> Rbs = new List<Rigidbody>();
    public List<Collider> colliders = new List<Collider>();
    public SkinnedMeshRenderer MR;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        checkforRigids(gameObject);
        for (int i = 0; i < colliders.Count; i++)
        {
            colliders[i].enabled = false;
        }
        for (int i = 0; i < Rbs.Count; i++)
        {
            Rbs[i].isKinematic = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.P)) 
        {
            TurnOnStuff();
        }*/
    }

    public void TurnOnStuff()
    {
        anim.enabled = false;
        for (int i = 0; i < colliders.Count; i++)
        {
            colliders[i].enabled = true;
        }
        for (int i = 0; i < Rbs.Count; i++)
        {
            Rbs[i].isKinematic = false;
        }

        Rbs[0].AddForce(0,12500,0);
        Rbs[0].AddForce(Rbs[0].transform.forward * -2000);
        MR.material.color = Color.grey;   
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
            if (_gam.transform.GetChild(i).GetComponent<Collider>() != null && _gam.transform.GetChild(i).transform.tag != "DontTurnOff")
            {
                colliders.Add(_gam.transform.GetChild(i).gameObject.GetComponent<Collider>());
                print("GotColliderp");
            }

            if (_gam.transform.GetChild(i).childCount > 0)
            {
                checkforRigids(_gam.transform.GetChild(i).gameObject);
                /*for (int ii = 0; ii < _gam.transform.GetChild(i).childCount; ii++)
                {
                    print("Diving into" + _gam.transform.GetChild(ii).gameObject);
                    checkforRigids(_gam.transform.GetChild(ii).gameObject);
                }*/
            }
        }
    }
}
