using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBehaviour : MonoBehaviour
{
    public float relativeAmount;
    public int currentWave;

    public List<GameObject> enms = new List<GameObject>();

    public List<GameObject> Waves = new List<GameObject>();

    public List<GameObject> SpawnPoints = new List<GameObject>();
    public int spw;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)){
            NewWave();
        }
    }

    public void NewWave()
    {
        for (int i = 0; i < Waves[currentWave].transform.childCount; i++)
        {
            GameObject ed = Instantiate(Waves[currentWave].transform.GetChild(i).gameObject, SpawnPoints[spw].transform.position, transform.rotation, transform);

            ed.GetComponent<EnemyShoot>().Timeline = gameObject;
            ed.GetComponent<EnemyShoot>().Started();

            spw += 1;
            if (spw > SpawnPoints.Count)
            {
                spw = 0;
            }
        }

       currentWave += 1;
    }

    public void EnemyDie(GameObject _Enem)
    {
        relativeAmount -= 1;
    }
}
