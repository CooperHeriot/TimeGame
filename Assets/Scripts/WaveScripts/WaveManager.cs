using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour
{
    public float currentNumber;

    public List<GameObject> WaveBehavs = new List<GameObject>();

    private TimelineManager TM;

    public float Cooldown;
    private float CD;

    public float enems;

    public GameObject TextHolder;
    public TextMeshProUGUI Tm;

    //public GameObject Currentdoors;

    [Header("Paradox Stuff")]
    public bool StopWaves;
    // Start is called before the first frame update
    void Start()
    {
        TM = GetComponent<TimelineManager>();

        //UpdateWaves();
        CD = Cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        enems = FindObjectsOfType<EnemyHealth>().Length;

        if (enems == 0)
        {
            Cooldown -= 1 * Time.deltaTime;
            if (StopWaves == false)
            {
                TextHolder.SetActive(true);
                Tm.text = ("New wave in: " + Cooldown.ToString("F0"));
            }            
        }

        if (Cooldown <= 0)
        {
            if (StopWaves == false)
            {
                Cooldown = CD;
                nextWave();
            } else
            {
                for (int i = 0; i < WaveBehavs.Count; i++)
                {
                    WaveBehavs[i].GetComponent<WaveBehaviour>().openDoors();
                }
            }           

            TextHolder.SetActive(false);

            /* for (int i = 0; i < Currentdoors.transform.childCount; i++)
             {
                 if (Currentdoors.transform.GetChild(i).GetComponent<DoorGoAway>() != null)
                 {
                     Currentdoors.transform.GetChild(i).GetComponent<DoorGoAway>().die();
                 }               
             }*/
            
        }

        /*if (Input.GetKeyDown(KeyCode.P)){
            nextWave();
        }*/

        /*if (WaveBehavs.) {
        }*/
    }

    public void UpdateWaves(GameObject _Wave)
    {
        /*for (int i = 0; i < TM.Lines.Count; i++)
        {
            WaveBehavs.Add(TM.Lines[i]);

            currentNumber = WaveBehavs.Count;
        }*/
        WaveBehavs.Add(_Wave);

        currentNumber = WaveBehavs.Count;

        /*for (int i = 0; i < WaveBehavs.Count; i++)
        {
            activeWaves += WaveBehavs[i].GetComponent<WaveBehaviour>().relativeAmount;
        }*/
    }

    public void removeWave(GameObject _Wave)
    {
        WaveBehavs.Remove(_Wave);

        currentNumber = WaveBehavs.Count;
    }

    public void nextWave()
    {
        for (int i = 0; i < WaveBehavs.Count; i++)
        {
            WaveBehavs[i].GetComponent<WaveBehaviour>().NewWave();
        }
    }
}
