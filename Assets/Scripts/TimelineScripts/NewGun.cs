using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGun : MonoBehaviour
{
    public GameObject ThisTimeLine;
    private Gunbehav GB;

    private TimelineManager TM;

    [Header("Attributes")]
    public Sprite GunSprite;
    public float FRate;
    public bool Auto;
    public GameObject Bullet;
    // Start is called before the first frame update
    void Start()
    {
        TM = FindObjectOfType<TimelineManager>();

        GB = ThisTimeLine.GetComponent<TimelineBehav>().Player.GetComponent<Gunbehav>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            MakeAnew();
        }
    }

    public void MakeAnew()
    {
        TM.createNewTimeline(ThisTimeLine,  GunSprite,  FRate,  Auto,  Bullet);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerMove>() != null)
        {
            MakeAnew();
        }
    }
}
