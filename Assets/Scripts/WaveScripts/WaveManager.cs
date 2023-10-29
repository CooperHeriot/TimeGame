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

            TextHolder.SetActive(true);
            Tm.text = ("New wave in: " + Cooldown.ToString("F0"));
        }

        if (Cooldown <= 0)
        {
            Cooldown = CD;
            nextWave();

            TextHolder.SetActive(false);
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
