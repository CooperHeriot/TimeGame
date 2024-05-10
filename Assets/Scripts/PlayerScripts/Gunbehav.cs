using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
//using TMPro;

public class Gunbehav : MonoBehaviour
{
    private bool CantShoot;
    private PlayerMove PM;
    [Header("Current Timeline")]
    public GameObject Timeline;

    [Header("Gun stuff")]
    public GameObject Model, point;

    public GameObject firepoint, bullet;

    public bool firstGun;

    [Header("Fire Rate")]
    public float fireRate;
    private float currentRate;

    public bool auto;

    [Header("Ammo")]
    public float currentAmmo = 10, maxAmmo, reloadTime;
    public float RTime;

    [Header("Gun Sprite")]
    public SpriteRenderer GSprite;
    public GameObject GunMod;
    public Animator GunAnim;

    [Header("Is this the prime timeline player")]
    public bool Prime = true;

    [Header("Enable first person mode")]
    public bool FPSMode;

    [Header("Ammo counter and Mark")]
    public GameObject Amo;
    public GameObject Mark;

    private Color col1;

    [Header("Gun Sprite")]
    public AudioClip GunSound;
    // Start is called before the first frame update
    void Start()
    {
        PM = GetComponent<PlayerMove>();

        currentRate = fireRate;

        if (maxAmmo == 0)
        {
            maxAmmo = currentAmmo;
        }
        /* if (RTime == 0)
         {
             RTime = reloadTime;
         }*/

        if (firstGun == true)
        {
            col1 = Amo.GetComponent<TextMeshProUGUI>().color;
            Amo.GetComponent<TextMeshProUGUI>().color = Color.clear;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CantShoot = PM.stopped;

        //point at cursor
        if (Time.timeScale > 0 && Prime == true && FPSMode == false)
        {
            Model.transform.rotation = Quaternion.LookRotation(point.transform.position - Model.transform.position);
        }

        //SHOOT
        if (Time.timeScale > 0 && CantShoot == false)
        {
            if (auto == false)
            {
                if (Input.GetMouseButtonDown(0) && currentRate >= fireRate && currentAmmo > 0)
                {
                    Instantiate(bullet, firepoint.transform.position, firepoint.transform.rotation, Timeline.transform);
                    currentRate = 0;

                    currentAmmo -= 1;

                    GunAnim.Play("GunSHOOT");
                    Timeline.GetComponent<AudioBehav>().PlaySound(GunSound);
                }
            }
            else
            {
                if (Input.GetMouseButton(0) && currentRate >= fireRate && currentAmmo > 0)
                {
                    Instantiate(bullet, firepoint.transform.position, firepoint.transform.rotation, Timeline.transform);
                    currentRate = 0;

                    currentAmmo -= 1;

                    GunAnim.Play("GunSHOOT");
                    Timeline.GetComponent<AudioBehav>().PlaySound(GunSound);
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

    public void NewGun(Sprite _Gunn, float _FRate, bool _Auto, GameObject _Bullet, float _Ammo, GameObject _Mod)
    {
        if (firstGun == true)
        {
            firstGun = false;

            Amo.GetComponent<TextMeshProUGUI>().color = col1;
        }

        GSprite.sprite = _Gunn;
        fireRate = _FRate;
        auto = _Auto;
        bullet = _Bullet;

        currentAmmo = _Ammo;
        maxAmmo = _Ammo;

        if (_Mod != null)
        {
            GameObject newGun = Instantiate(_Mod, GunMod.transform.position, GunMod.transform.rotation, GunMod.transform.parent.transform);
            newGun.transform.localScale = Vector3.one;

            Destroy(GunMod);

            GunMod = newGun;
        }    
    }
}
