using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newWave : MonoBehaviour
{
    public WaveManager WM;

    public List<GameObject> nWaves = new List<GameObject>();

    public List<GameObject> nSpawnPoints = new List<GameObject>();

    public GameObject nParaEnem;
    // Start is called before the first frame update
    void Start()
    {
        WM = FindObjectOfType<WaveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMove>() != null)
        {
            WM.StopWaves = false;

            for (int i = 0; i < WM.WaveBehavs.Count; i++)
            {
                WM.WaveBehavs[i].GetComponent<WaveBehaviour>().currentWave = 0;
                WM.WaveBehavs[i].GetComponent<WaveBehaviour>().Waves = nWaves;
                WM.WaveBehavs[i].GetComponent<WaveBehaviour>().SpawnPoints = nSpawnPoints;
                WM.WaveBehavs[i].GetComponent<WaveBehaviour>().paradaoxEnem = nParaEnem;
            }

            Destroy(gameObject);
        }
    }
}
