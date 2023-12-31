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

    [Header("Ammo")]
    public float currentAmmo = 10, maxAmmo, reloadTime;
    public float RTime;

    [Header("Gun Sprite")]
    public SpriteRenderer GSprite;

    [Header("Is this the prime timeline player")]
    public bool Prime = true;

    [Header("Enable first person mode")]
    public bool FPSMode;
    // Start is called before the first frame update
    void Start()
    {
        currentRate = fireRate;

        if (maxAmmo == 0)
        {
            maxAmmo = currentAmmo;
        }
        /* if (RTime == 0)
         {
             RTime = reloadTime;
         }*/
    }

    // Update is called once per frame
    void Update()
    {
        //point at cursor
        if (Time.timeScale > 0 && Prime == true && FPSMode == false)
        {
            Model.transform.rotation = Quaternion.LookRotation(point.transform.position - Model.transform.position);
        }

        //SHOOT
        if (Time.timeScale > 0)
        {
            if (auto == false)
            {
                if (Input.GetMouseButtonDown(0) && currentRate >= fireRate && currentAmmo > 0)
                {
                    Instantiate(bullet, firepoint.transform.position, firepoint.transform.rotation, Timeline.transform);
                    currentRate = 0;

                    currentAmmo -= 1;
                }
            }
            else
            {
                if (Input.GetMouseButton(0) && currentRate >= fireRate && currentAmmo > 0)
                {
                    Instantiate(bullet, firepoint.transform.position, firepoint.transform.rotation, Timeline.transform);
                    currentRate = 0;

                    currentAmmo -= 1;
                }
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                currentAmmo = 0;
            }
        }

        if (currentAmmo < 1)
        {
            reloadTime -= 1 * Time.deltaTime;
        }

        if (reloadTime <= 0)
        {
            reloadTime = RTime;
            currentAmmo = maxAmmo;
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

    public void NewGun(Sprite _Gunn, float _FRate, bool _Auto, GameObject _Bullet, float _Ammo)
    {
        GSprite.sprite = _Gunn;
        fireRate = _FRate;
        auto = _Auto;
        bullet = _Bullet;

        currentAmmo = _Ammo;
        maxAmmo = _Ammo;
    }
}
