using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class TimelineManager : MonoBehaviour
{
    public float maxAmount, currentAmount = 1, ActiveLines, offset = 30;

    public List<GameObject> Lines = new List<GameObject>();
    private List<GameObject> inactiveLines = new List<GameObject>();
    public List<GameObject> lineViwer = new List<GameObject>();
    public List<GameObject> reverseLineViwer = new List<GameObject>();
    //public List<GameObject> SpawnPoints = new List<GameObject>();
    public GameObject primeTime;

    public Quaternion primmeRot;

    private CamManager CM;

    private WaveManager WM;
    [Header("Game Over")]
    public GameObject GameOver;
    public bool lsott;

    private NewNavMesh NV;

    private float Total = 1;

    [Header("Anti Lag")]
    public GameObject levl;
    private bool DontCreate = false;
    public float LAmount;
    private float Lrount = 1;
    public NewGun NG;
    // Start is called before the first frame update
    void Start()
    {
        //difficulty stuff
        int difficulty = PlayerPrefs.GetInt("Difficulty");

        if (difficulty == 0)
        {
            difficulty = 1;
        }

        if (difficulty == 1)
        {
            GetComponent<TimelineManager>().maxAmount = 2;
        }
        else
        {
            GetComponent<TimelineManager>().maxAmount = 4;
        }


        GameOver.SetActive(false);

        Lines.Add(primeTime);

        primeTime.GetComponent<TimelineBehav>().becomePrime();

        currentAmount = Lines.Count;

        CM = GetComponent<CamManager>();

        WM = GetComponent<WaveManager>();

        NV = GetComponent<NewNavMesh>();

        WM.UpdateWaves(primeTime);

        if (levl != null)
        {
            DontCreate = true;
            LAmount = maxAmount - 1;
            //LAmount = maxAmount;

            for (int i = 0; i < LAmount; i++)
            {
                //Instantiate(levl, new Vector3(0, primeTime.transform.position.y + (offset * Lrount), 0), transform.rotation, transform);
                //Lrount += 1;


                GameObject NewTL = Instantiate(primeTime, new Vector3(0, primeTime.transform.position.y + (offset * Lrount), 0), transform.rotation, transform);
                Lines.Add(NewTL);

                NewTL.GetComponent<TimelineBehav>().OnOff = !NewTL.GetComponent<TimelineBehav>().OnOff;

               // CM.Cams.Add(NewTL.GetComponent<TimelineBehav>().Cam);
                NewTL.GetComponent<TimelineBehav>().prime = false;

                NewTL.GetComponent<TimelineBehav>().newGunForPlayer(NG.GunSprite, NG.FRate, NG.Auto, NG.Bullet, NG.Ammo, NG.GunMod, NG.Soun);

                //WM.UpdateWaves(NewTL);

               // NV.makeNew();

                Total += 1;

                Lrount += 1;

                //NewTL.GetComponent<WaveBehaviour>().KillAll();

               // NewTL.SetActive(false);
                inactiveLines.Add(NewTL);
            }
            NV.makeNew();
            for (int i = 0; i < inactiveLines.Count; i++)
            {
                inactiveLines[i].SetActive(false);
            }
        }
       
        CheckActiveLines();

        //currentAmount = Lines.Count;

        if (DontCreate == false)
        {
            currentAmount = Lines.Count;
        }
        else
        {
            currentAmount = ActiveLines;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAmount == 0)
        {
            GameOver.SetActive(true);

            lsott = true;
        }
    }

    public void createNewTimeline(GameObject _TLine, Sprite _Gunn, float _FRate, bool _Auto, GameObject _Bullet, float _ammo, GameObject _Mod, AudioClip _sfx)
    {
       // CheckActiveLines();
        if (DontCreate == false)
        {
            if (currentAmount < maxAmount)
            {
                // GameObject NewTL = Instantiate(_TLine, new Vector3(primeTime.transform.position.x + (offset * currentAmount), 0, primeTime.transform.position.z + (offset * currentAmount)), transform.rotation, transform);
                //if (_TLine.GetComponent<TimelineBehav>().OnOff == false) { }
                GameObject NewTL = Instantiate(_TLine, new Vector3(0, primeTime.transform.position.y + (offset * Total), 0), transform.rotation, transform);
                Lines.Add(NewTL);

                NewTL.GetComponent<TimelineBehav>().OnOff = !NewTL.GetComponent<TimelineBehav>().OnOff;

                CM.Cams.Add(NewTL.GetComponent<TimelineBehav>().Cam);
                NewTL.GetComponent<TimelineBehav>().prime = false;

                NewTL.GetComponent<TimelineBehav>().newGunForPlayer(_Gunn, _FRate, _Auto, _Bullet, _ammo, _Mod, _sfx);

                WM.UpdateWaves(NewTL);

                NV.makeNew();

                Total += 1;
            }
        } else
        {
            //new Code
            //CheckActiveLines();
            if(ActiveLines < Lines.Count)
            {
                inactiveLines[0].GetComponent<TimelineBehav>().Player.GetComponent<PlayerHealth>().currentHealth = 3;
                inactiveLines[0].GetComponent<TimelineBehav>().Player.GetComponent<PlayerHealth>().dead = false;

                inactiveLines[0].SetActive(true);               
                //inactiveLines[0].GetComponent<WaveBehaviour>().KillAll();
                //inactiveLines[0].GetComponent<TimelineBehav>().prime = false;
                inactiveLines[0].GetComponent<TimelineBehav>().newGunForPlayer(_Gunn, _FRate, _Auto, _Bullet, _ammo, _Mod, _sfx);
                
                //PLAYER STUFF
                Vector3 Playerpos = _TLine.GetComponent<TimelineBehav>().Player.transform.localPosition;

                inactiveLines[0].GetComponent<TimelineBehav>().Player.transform.localPosition = Playerpos;
                inactiveLines[0].GetComponent<TimelineBehav>().Player.transform.rotation = _TLine.GetComponent<TimelineBehav>().Player.transform.rotation;
                inactiveLines[0].GetComponent<TimelineBehav>().Player.gameObject.GetComponentInChildren<CamMove>().transform.rotation = _TLine.GetComponent<TimelineBehav>().Player.gameObject.GetComponentInChildren<CamMove>().transform.rotation;

                CM.Cams.Add(inactiveLines[0].GetComponent<TimelineBehav>().Cam);

                //disableTriggers
                for (int i = 0; i < _TLine.GetComponent<WaveBehaviour>().WaveTriggers.Count; i++)
                {
                    if (_TLine.GetComponent<WaveBehaviour>().WaveTriggers[i] == null)
                    {
                        Destroy(inactiveLines[0].GetComponent<WaveBehaviour>().WaveTriggers[i].gameObject);
                    }                    
                }
                inactiveLines[0].GetComponent<WaveBehaviour>().currentWave = _TLine.GetComponent<WaveBehaviour>().currentWave;
                inactiveLines[0].GetComponent<WaveBehaviour>().Waves = _TLine.GetComponent<WaveBehaviour>().Waves;
                inactiveLines[0].GetComponent<WaveBehaviour>().chance = _TLine.GetComponent<WaveBehaviour>().chance;

                inactiveLines[0].GetComponent<TimelineBehav>().Player.GetComponent<PlayerMove>().Tier = _TLine.GetComponent<TimelineBehav>().Player.GetComponent<PlayerMove>().Tier;
                //add enemies
                for (int i = 0; i < _TLine.GetComponent<WaveBehaviour>().enms.Count; i++)
                {
                    //GameObject ed = Instantiate(_TLine.GetComponent<WaveBehaviour>().enms[i], _TLine.GetComponent<WaveBehaviour>().enms[i].transform.localPosition, _TLine.GetComponent<WaveBehaviour>().enms[i].transform.rotation, inactiveLines[0].transform);
                    GameObject ed = Instantiate(_TLine.GetComponent<WaveBehaviour>().enms[i], new Vector3(_TLine.GetComponent<WaveBehaviour>().enms[i].transform.position.x, inactiveLines[0].transform.position.y, _TLine.GetComponent<WaveBehaviour>().enms[i].transform.position.z), _TLine.GetComponent<WaveBehaviour>().enms[i].transform.rotation, inactiveLines[0].transform);

                    /*if (Vector3.Distance(ed.transform.position, inactiveLines[0].transform.position) > 100)
                    {
                        if (ed.transform.position.y > inactiveLines[0].transform.position.y)
                        {
                            print("down");
                            ed.transform.position = new Vector3(ed.transform.position.x, ed.transform.position.y - (Vector3.Distance(ed.transform.position, inactiveLines[0].transform.position) + 0.5f), ed.transform.position.z);
                        } else
                        {
                            print("up");
                            ed.transform.position = new Vector3(ed.transform.position.x, ed.transform.position.y + (Vector3.Distance(ed.transform.position, inactiveLines[0].transform.position) + 0.5f), ed.transform.position.z);
                        }
                    }*/
                    //ed.transform.localPosition = new Vector3(_TLine.GetComponent<WaveBehaviour>().enms[i].transform.localPosition.x, 0, _TLine.GetComponent<WaveBehaviour>().enms[i].transform.localPosition.z);

                    ed.GetComponent<EnemyShoot>().Timeline = inactiveLines[0].gameObject;
                    ed.GetComponent<EnemyShoot>().Started();

                    inactiveLines[0].GetComponent<WaveBehaviour>().enms.Add(ed);
                    inactiveLines[0].GetComponent<WaveBehaviour>().relativeAmount = inactiveLines[0].GetComponent<WaveBehaviour>().enms.Count;
                }

                for (int i = 0; i < inactiveLines[0].GetComponent<TimelineBehav>().Dors.Count; i++)
                {
                    if (_TLine.GetComponent<TimelineBehav>().Dors[i] == null)
                    {
                        inactiveLines[0].GetComponent<TimelineBehav>().Dors[i].SetActive(false);
                        inactiveLines[0].GetComponent<WaveBehaviour>().SpawnPoints = inactiveLines[0].GetComponent<TimelineBehav>().Dors[i].GetComponent<DoorControls>().nSpawnPoints;
                    }
                }

                for (int i = 0; i < inactiveLines[0].GetComponent<TimelineBehav>().Buttons.Count; i++)
                {
                    inactiveLines[0].GetComponent<TimelineBehav>().Buttons[i].GetComponent<TimeButton>().tier = _TLine.GetComponent<TimelineBehav>().Buttons[i].GetComponent<TimeButton>().tier;
                    if (_TLine.GetComponent<TimelineBehav>().Buttons[i] == null)
                    {
                        inactiveLines[0].GetComponent<TimelineBehav>().Buttons[i].SetActive(false);                       
                    }
                }

                for (int i = 0; i < inactiveLines[0].GetComponent<TimelineBehav>().Fields.Count; i++)
                {                   
                    if (_TLine.GetComponent<TimelineBehav>().Fields[i].activeInHierarchy == true)
                    {
                        inactiveLines[0].GetComponent<TimelineBehav>().Fields[i].SetActive(true);
                        inactiveLines[0].GetComponent<WaveBehaviour>().Currentdoors = inactiveLines[0].GetComponent<TimelineBehav>().Fields[i];
                    }
                }
                /*for (int i = 0; i < _TLine.GetComponent<WaveBehaviour>().SpawnPoints.Count; i++)
                {
                    if (i < inactiveLines[0].GetComponent<WaveBehaviour>().SpawnPoints.Count)
                    {
                        inactiveLines[0].GetComponent<WaveBehaviour>().SpawnPoints[i] = _TLine.GetComponent<WaveBehaviour>().SpawnPoints[i];
                    }           
                }*/


                WM.UpdateWaves(inactiveLines[0]);

                //inactiveLines.Remove(inactiveLines[0]);
                inactiveLines.RemoveAt(0);
                //CheckActiveLines();
            }
            //CheckActiveLines();
        }
        
        
        if (currentAmount >= maxAmount)
        {
            for (int i = 0; i < Lines.Count; i++)
            {
                if (i > maxAmount)
                {
                    Destroy(Lines[i].gameObject);
                    Lines.Remove(Lines[i]);
                    //CheckActiveLines();
                }
            }
        }
        CheckActiveLines();
        //currentAmount = Lines.Count;
        currentAmount = ActiveLines;
    }

    public void eraseTimeline(GameObject _TLine)
    {
        //CheckActiveLines();
        if (DontCreate == false)
        {
            WM.removeWave(_TLine);

            Destroy(_TLine.gameObject);
            Lines.Remove(_TLine);

            //WM.removeWave(_TLine);

            if (_TLine.GetComponent<TimelineBehav>().prime == true)
            {
                Lines[0].GetComponent<TimelineBehav>().becomePrime();
                primeTime = Lines[0];
            }

            CM.Cams.Remove(_TLine.GetComponent<TimelineBehav>().Cam);

            //currentAmount = Lines.Count;
            currentAmount = ActiveLines;

            NV.makeNew();
        } else
        {
            if (_TLine.GetComponent<TimelineBehav>().prime == true)
            {
                int TMM = 0;

                for (int i = 0; i < Lines.Count; i++)
                {
                    if (Lines[i] == _TLine)
                    {
                        TMM = i;
                    }
                }

                reverseLineViwer.Remove(_TLine);
                if (reverseLineViwer.Count > 0)
                {
                    reverseLineViwer[0].GetComponent<TimelineBehav>().becomePrime();
                    primeTime = reverseLineViwer[0];
                }
                
                /* if (TMM + 1 > reverseLineViwer.Count)
                 {
                     reverseLineViwer[0].GetComponent<TimelineBehav>().becomePrime();
                     primeTime = reverseLineViwer[0];
                 } else
                 {
                     reverseLineViwer[TMM + 1].GetComponent<TimelineBehav>().becomePrime();
                     primeTime = reverseLineViwer[TMM + 1];
                 }    */
            }

            _TLine.GetComponent<WaveBehaviour>().KillAll();
            _TLine.GetComponent<WaveBehaviour>().KillAll();
            _TLine.GetComponent<WaveBehaviour>().KillAll();
            _TLine.GetComponent<WaveBehaviour>().KillAll();
            WM.removeWave(_TLine);
            
            _TLine.gameObject.SetActive(false);
            CM.Cams.Remove(_TLine.GetComponent<TimelineBehav>().Cam);
            //CheckActiveLines();

            inactiveLines.Add(_TLine);
        }
        CheckActiveLines();
    }

    public void CheckActiveLines()
    {
        ActiveLines = 0;
        reverseLineViwer.Clear();
        for (int i = 0; i < Lines.Count; i++)
        {
            
            if (Lines[i].activeInHierarchy == true)
            {
                

                ActiveLines += 1;
                if (inactiveLines.Count > 1)
                {
                    //inactiveLines.Remove(Lines[i]);
                }else
                {
                   // inactiveLines.Clear();
                }


                reverseLineViwer.Add(Lines[i]);
                //inactiveLines.Count -= 1;
            } else
            {
                ///  inactiveLines.Add(Lines[i]);
                reverseLineViwer.Remove(Lines[i]);
            }
        }

        currentAmount = ActiveLines;
        lineViwer = inactiveLines;

        //NV.makeNew();
    }

    public void alignCharacters()
    {
        for (int i = 0; i < Lines.Count;i++)
        {
            //if (Lines[i].GetComponent<TimelineBehav>().prime == false) 
            if (Lines[i] != primeTime) 
            {
                Lines[i].GetComponent<TimelineBehav>().Player.transform.position = new Vector3(primeTime.GetComponent<TimelineBehav>().Player.transform.position.x, Lines[i].GetComponent<TimelineBehav>().Player.transform.position.y, primeTime.GetComponent<TimelineBehav>().Player.transform.position.z);
                Lines[i].GetComponent<TimelineBehav>().Player.transform.rotation = new Quaternion(primeTime.GetComponent<TimelineBehav>().Player.transform.rotation.x, primeTime.GetComponent<TimelineBehav>().Player.transform.rotation.y, primeTime.GetComponent<TimelineBehav>().Player.transform.rotation.z, primeTime.GetComponent<TimelineBehav>().Player.transform.rotation.w);
                //Lines[i].GetComponent<TimelineBehav>().Player.transform.position = new Vector3(primeTime.GetComponent<TimelineBehav>().Player.transform.position.x, primeTime.GetComponent<TimelineBehav>().Player.transform.position.y, primeTime.GetComponent<TimelineBehav>().Player.transform.position.z);
                print("Algined playa");
            }
        }
    }
}
