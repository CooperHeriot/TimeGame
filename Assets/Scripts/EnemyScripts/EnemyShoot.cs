using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class EnemyShoot : MonoBehaviour
{
    [Header("Is this guy active")]
    public bool online;

    [Header("Player")]
    public GameObject target;
    public GameObject Timeline;

    [Header("Gun stuff")]
    public GameObject Model;

    public GameObject firepoint, bullet;

    [Header("Fire Rate")]
    public float fireRate;
    private float currentRate, birerate = 1;

    public bool NeedLineOSight, InLine;
    public LayerMask LM;

    [Header("Gun Sprite")]
    public SpriteRenderer GSprite;
    // Start is called before the first frame update
    void Start()
    {
        Started();
    }

    public void Started()
    {
        target = Timeline.GetComponent<TimelineBehav>().Player;

        if (PlayerPrefs.GetInt("Difficulty") == 3)
        {
            birerate = 2;
        } else
        {
            birerate = 1;
        }

       // currentRate = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (online == true)
        {
            //RaycastHit hit;

            if (Time.timeScale > 0)
            {
                Model.transform.rotation = Quaternion.LookRotation(target.transform.position - Model.transform.position);
            }

            if (currentRate >= fireRate)
            {
                if (NeedLineOSight == true && InLine == true)
                {
                    Instantiate(bullet, firepoint.transform.position, firepoint.transform.rotation, Timeline.transform);
                    currentRate = 0;
                }
                else
                {
                    if (NeedLineOSight == false)
                    {
                        Instantiate(bullet, firepoint.transform.position, firepoint.transform.rotation, Timeline.transform);
                        currentRate = 0;
                    }
                }

            }

            if (Physics.Raycast(firepoint.transform.position, Model.transform.forward, 100, LM))
            {
                InLine = false;
            }
            else
            {
                InLine = true;
            }


            if (currentRate > fireRate)
            {
                currentRate = fireRate;
            }
            else
            {
                currentRate += birerate * Time.deltaTime;
            }
            if (currentRate < 0)
            {
                currentRate = 0;
            }
        }
        
    }
}
