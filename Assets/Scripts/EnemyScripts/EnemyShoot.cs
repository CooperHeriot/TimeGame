using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class EnemyShoot : MonoBehaviour
{
    [Header("Player")]
    public GameObject target;
    public GameObject Timeline;

    [Header("Gun stuff")]
    public GameObject Model;

    public GameObject firepoint, bullet;

    [Header("Fire Rate")]
    public float fireRate;
    private float currentRate;

    public bool NeedLineOSight, InLine;

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

       // currentRate = fireRate;
    }

    // Update is called once per frame
    void Update()
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
            } else
            {
                if (NeedLineOSight == false)
                {
                    Instantiate(bullet, firepoint.transform.position, firepoint.transform.rotation, Timeline.transform);
                    currentRate = 0;
                }
            }
            
        }

        if (Physics.Raycast(firepoint.transform.position,Model.transform.forward, 100, 3))
        {
            InLine = false;
        } else
        {
            InLine = true;
        }


        if (currentRate > fireRate)
        {
            currentRate = fireRate;
        }
        else
        {
            currentRate += 1 * Time.deltaTime;
        }
        if (currentRate < 0)
        {
            currentRate = 0;
        }
    }
}
