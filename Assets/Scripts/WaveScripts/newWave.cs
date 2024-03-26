using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newWave : MonoBehaviour
{
    public WaveManager WM;

    public List<GameObject> nWaves = new List<GameObject>();

    public List<GameObject> nSpawnPoints = new List<GameObject>();

    public GameObject nParaEnem, doors;

    public int me, pointt;

    public GameObject Paent;


    // Start is called before the first frame update
    void Start()
    {
        WM = FindObjectOfType<WaveManager>();

        doors.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < WM.WaveBehavs.Count; i++)
        {
            if (WM.WaveBehavs[i] == Paent)
            {
                me = i;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMove>() != null)
        {
            /*WM.StopWaves = false;

            //int me;



            for (int i = 0; i < WM.WaveBehavs.Count; i++)
            {
                if (WM.WaveBehavs[i] == transform.parent)
                {
                    me = i;
                }

                WM.WaveBehavs[i].GetComponent<WaveBehaviour>().currentWave = 0;
                WM.WaveBehavs[i].GetComponent<WaveBehaviour>().Waves = nWaves;
                WM.WaveBehavs[i].GetComponent<WaveBehaviour>().SpawnPoints = nSpawnPoints;
                WM.WaveBehavs[i].GetComponent<WaveBehaviour>().paradaoxEnem = nParaEnem;
            }

            WM.WaveBehavs[me].GetComponent<WaveBehaviour>().currentWave = 0;
            WM.WaveBehavs[me].GetComponent<WaveBehaviour>().Waves = nWaves;
            WM.WaveBehavs[me].GetComponent<WaveBehaviour>().SpawnPoints = nSpawnPoints;
            WM.WaveBehavs[me].GetComponent<WaveBehaviour>().paradaoxEnem = nParaEnem;

            Destroy(gameObject);*/

            MakeAnew();
        }
    }

    public void MakeAnew()
    {
        PlayerPrefs.SetInt("point", pointt);

        WM.StopWaves = false;
        WM.Cooldown = 3;

        //int me;



        /*for (int i = 0; i < WM.WaveBehavs.Count; i++)
        {
            if (WM.WaveBehavs[i] == transform.parent)
            {
                me = i;
            }

            WM.WaveBehavs[i].GetComponent<WaveBehaviour>().currentWave = 0;
            WM.WaveBehavs[i].GetComponent<WaveBehaviour>().Waves = nWaves;
            WM.WaveBehavs[i].GetComponent<WaveBehaviour>().SpawnPoints = nSpawnPoints;
            WM.WaveBehavs[i].GetComponent<WaveBehaviour>().paradaoxEnem = nParaEnem;
        }*/
        
        doors.SetActive(true);

        WM.WaveBehavs[me].GetComponent<WaveBehaviour>().currentWave = 0;
        WM.WaveBehavs[me].GetComponent<WaveBehaviour>().Waves = nWaves;
        WM.WaveBehavs[me].GetComponent<WaveBehaviour>().SpawnPoints = nSpawnPoints;
        WM.WaveBehavs[me].GetComponent<WaveBehaviour>().paradaoxEnem = nParaEnem;
        WM.WaveBehavs[me].GetComponent<WaveBehaviour>().Currentdoors = doors;


        print("workin" + pointt);
        Destroy(gameObject);
    }
}
