using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControls : MonoBehaviour
{
    public GameObject door;

    public WaveBehaviour WM;

    public List<GameObject> nSpawnPoints = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        door.SetActive(false);

        //WM = FindObjectOfType<WaveManager>();

        /*for (int i = 0; i < WM.WaveBehavs.Count; i++)
        {
            if (WM.WaveBehavs[i] == Paent)
            {
                me = i;
            }
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        //ddsaf
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMove>() != null)
        {
            door.SetActive(true);
            //WM.GetComponent<WaveBehaviour>().SpawnPoints = nSpawnPoints;
            WM.SpawnPoints = nSpawnPoints;
            Destroy(gameObject);
        }
    }
}
