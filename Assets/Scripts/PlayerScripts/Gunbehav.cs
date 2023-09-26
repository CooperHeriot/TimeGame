using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Gunbehav : MonoBehaviour
{
    [Header("Current Timeline")]
    public GameObject Timeline;

    [Header("Gun stuff")]
    public GameObject Model, point;

    public GameObject firepoint, bullet;

    [Header("Fire Rate")]
    public float fireRate;
    private float currentRate;

    public bool auto;
    // Start is called before the first frame update
    void Start()
    {
        currentRate = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        //point at cursor
        if (Time.timeScale > 0)
        {
            Model.transform.rotation = Quaternion.LookRotation(point.transform.position - Model.transform.position);
        }

        //SHOOT
        if (Time.timeScale > 0)
        {
            if (auto == false)
            {
                if (Input.GetMouseButtonDown(0) && currentRate >= fireRate)
                {
                    Instantiate(bullet, firepoint.transform.position, firepoint.transform.rotation, Timeline.transform);
                    currentRate = 0;
                }
            }
            else
            {
                if (Input.GetMouseButton(0) && currentRate >= fireRate)
                {
                    Instantiate(bullet, firepoint.transform.position, firepoint.transform.rotation, Timeline.transform);
                    currentRate = 0;
                }
            }
        }

        //currentRate Lock
        if (currentRate > fireRate)
        {
            currentRate = fireRate;
        } else
        {
            currentRate += 1 * Time.deltaTime;
        }
        if (currentRate < 0)
        {
            currentRate = 0;
        }
    }
}
