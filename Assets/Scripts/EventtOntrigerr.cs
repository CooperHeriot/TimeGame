using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventtOntrigerr : MonoBehaviour
{
    public UnityEvent even;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMove>() != null)
        {
            even.Invoke();
        }
    }
}
