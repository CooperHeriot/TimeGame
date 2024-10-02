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

    public GameObject CombatLog, combatlog1, canvers;
    public float killss, times;
    public bool once;
    [Header("Paradox Stuff")]
    public bool StopWaves;

    [Header("Paradox Stuff")]
    public AudioSource Combat, Calm;
    public float test;
    // Start is called before the first frame update
    void Start()
    {
        TM = GetComponent<TimelineManager>();

        //UpdateWaves();
        if (PlayerPrefs.GetInt("Difficulty") != 3)
        {
            CD = Cooldown;
        } else
        {
            CD = 1f;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        enems = FindObjectsOfType<EnemyHealth>().Length;

        if (StopWaves == false)
        {
            times += 1 * Time.deltaTime;
            once = true;
        }

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
                StartCoroutine(SetCombat());
            } else
            {
                for (int i = 0; i < WaveBehavs.Count; i++)
                {
                    WaveBehavs[i].GetComponent<WaveBehaviour>().openDoors();
                }
                
                if (once == true)
                {
                    once = false;
                    SummonLog(killss, times);
                    killss = 0;
                    times = 0;

                    TM.alignCharacters();
                    print("alignnned");
                    StartCoroutine(SetCalm());
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

    public void SummonLog(float kills, float timme)
    {
        GameObject logg = Instantiate(CombatLog, combatlog1.transform.position, transform.rotation, combatlog1.transform);
        logg.GetComponent<Combatlog>().kill = kills;
        logg.GetComponent<Combatlog>().ttime = timme;
        //logg.transform.position = Vector3.zero;
        logg.GetComponent<RectTransform>().position = combatlog1.GetComponent<RectTransform>().position;
    }

    public void SummonSummonLog()
    {
        SummonLog(killss, times);
        killss = 0;
        times = 0;
    }

    IEnumerator SetCombat()
    {
        //print("sdsdsf11111111");
        if (Combat.volume != 1)
        {
            float mt = 1;
            while (mt > 0)
            {
                Calm.volume = mt;
                Combat.volume = 1 - mt;
                //mt -= (20 / 100);
                mt -= 0.05f;
                //mt -= 99;
                test = mt;
                
                //print("sddfsadfsf");
                yield return new WaitForSeconds(0.1f);
            }
            Calm.volume = 0;
            Combat.volume = 1;
        } else
        {
            Calm.volume = 0; 
            Combat.volume = 1;
            yield return null;
        }     
    }

    IEnumerator SetCalm()
    {
        //print("sdsdsf11111111");
        if (Calm.volume != 1)
        {
            float mt = 1;
            while (mt > 0)
            {
                Combat.volume = mt;
                Calm.volume = 1 - mt;
                //mt -= (20 / 100);
                mt -= 0.05f;
                //mt -= 99;
                test = mt;

                //print("sddfsadfsf");
                yield return new WaitForSeconds(0.1f);
            }
            Combat.volume = 0;
            Calm.volume = 1;
        }
        else
        {
            Calm.volume = 0;
            Combat.volume = 1;
            yield return null;
        }
    }
}
