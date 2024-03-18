using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public GameObject player;
    public int points;
    public GameObject[] pointss;

    public GameObject startGun;
    // Start is called before the first frame update
    void Start()
    {
       player = FindObjectOfType<PlayerMove>().gameObject;

       points = PlayerPrefs.GetInt("point");

        if (points >= 0)
        {
            player.transform.position = pointss[points].transform.position;
            player.transform.rotation = pointss[points].transform.rotation;

            GameObject daGun = Instantiate(startGun, player.transform.position, player.transform.rotation);

            daGun.GetComponent<NewGun>().ThisTimeLine = GetComponent<TimelineManager>().primeTime;
        } else
        {
            PlayerPrefs.SetInt("point", -1);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnApplicationQuit()
    {
        //print("dasdassadasdsadasdasdsadasdasdasdsghfytuergs43");
        PlayerPrefs.SetInt("point", -1);
    }
}
