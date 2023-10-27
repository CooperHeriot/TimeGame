using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveBehaviour : MonoBehaviour
{
    public WaveManager WM;

    public float relativeAmount;
    public int currentWave;

    public List<GameObject> enms = new List<GameObject>();

    public List<GameObject> Waves = new List<GameObject>();

    public List<GameObject> SpawnPoints = new List<GameObject>();
    public int spw;

    public TextMeshProUGUI Tm;
    // Start is called before the first frame update
    void Start()
    {
        CheckColor();

        if (relativeAmount != 0)
        {
           // WM.enems += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.P)){
            NewWave();
        }*/

        spw = 0;
    }

    public void NewWave()
    {
        //WM.enems += 1;

        for (int i = 0; i < Waves[currentWave].transform.childCount; i++)
        {
            int spop;

            if (spw >= SpawnPoints.Count)
            {
                spop = 0;
            } else
            {
                spop = spw;
            }

            GameObject ed = Instantiate(Waves[currentWave].transform.GetChild(i).gameObject, SpawnPoints[spop].transform.position, transform.rotation, transform);

            ed.GetComponent<EnemyShoot>().Timeline = gameObject;
            ed.GetComponent<EnemyShoot>().Started();

            enms.Add(ed);
            relativeAmount = enms.Count;

            
            if (spw == SpawnPoints.Count)
            {
                spw = 0;
            }
            spw += 1;
        }

       currentWave += 1;

       Tm.text = ("Enemies: " + relativeAmount);
        CheckColor();
    }

    public void EnemyDie(GameObject _Enem)
    {
        enms.Remove(_Enem);
        relativeAmount = enms.Count;

        Tm.text = ("Enemies: " + relativeAmount);

        CheckColor();

        if (relativeAmount == 0)
        {
           // WM.enems -= 1;
        }
    }

    public void CheckColor()
    {
        if (relativeAmount != 0)
        {
            Tm.color = Color.black;
        }
        else
        {
            Tm.color = Color.white;

            //WM.activeWaves -= 1;
        }
    }
}
