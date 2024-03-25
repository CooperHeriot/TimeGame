using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public GameObject player;
    public int points, p2;
    public GameObject[] pointss;
    public GameObject SkipTutorial;

    public GameObject startGun;

    private Vector3 pv;
    private Quaternion Rv;
    // Start is called before the first frame update
    void Start()
    {
        pv = SkipTutorial.transform.position;
        Rv = SkipTutorial.transform.rotation;

       player = FindObjectOfType<PlayerMove>().gameObject;

       points = PlayerPrefs.GetInt("point");
       p2 = PlayerPrefs.GetInt("ptwo");

        if (points >= 0)
        {
            player.transform.position = pointss[points].transform.position;
            player.transform.rotation = pointss[points].transform.rotation;

            GameObject daGun = Instantiate(startGun, player.transform.position, player.transform.rotation);

            daGun.GetComponent<NewGun>().ThisTimeLine = GetComponent<TimelineManager>().primeTime;
        } else
        {
            PlayerPrefs.SetInt("point", -1);
            if (SkipTutorial != null && p2 == 1)
            {
                player.transform.position = pv;
                player.transform.rotation = Rv;

                GameObject daGun = Instantiate(startGun, player.transform.position, player.transform.rotation);

                daGun.GetComponent<NewGun>().ThisTimeLine = GetComponent<TimelineManager>().primeTime;
            }
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            PlayerPrefs.SetInt("ptwo", 0);
        }
    }

    void OnApplicationQuit()
    {
        //print("dasdassadasdsadasdasdsadasdasdasdsghfytuergs43");
        PlayerPrefs.SetInt("point", -1);
    }

    public void DoneTutorial()
    {
        PlayerPrefs.SetInt("ptwo", 1);
    }
}
