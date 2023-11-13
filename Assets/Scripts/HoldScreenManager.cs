using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldScreenManager : MonoBehaviour
{
    public GameObject Hold, PLAYER;
    private PlayerMove PM;
    // Start is called before the first frame update
    void Start()
    {
        PM = PLAYER.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PM.stopped == true)
        {
            Hold.SetActive(true);
        } else
        {
            Hold.SetActive(false);
        }
    }
}
