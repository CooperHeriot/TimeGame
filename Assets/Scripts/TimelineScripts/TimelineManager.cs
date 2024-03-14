using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineManager : MonoBehaviour
{
    public float maxAmount, currentAmount = 1, offset = 30;

    public List<GameObject> Lines = new List<GameObject>();
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
    public float LAmount;
    private float Lrount = 1;
    // Start is called before the first frame update
    void Start()
    {
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
            for (int i = 0; i < LAmount; i++)
            {
                Instantiate(levl, new Vector3(0, primeTime.transform.position.y + (offset * Lrount), 0), transform.rotation, transform);
                Lrount += 1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Lines.Count == 0)
        {
            GameOver.SetActive(true);

            lsott = true;
        }
    }

    public void createNewTimeline(GameObject _TLine, Sprite _Gunn, float _FRate, bool _Auto, GameObject _Bullet, float _ammo, GameObject _Mod)
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

            NewTL.GetComponent<TimelineBehav>().newGunForPlayer(_Gunn, _FRate, _Auto, _Bullet, _ammo, _Mod);

            WM.UpdateWaves(NewTL);

            NV.makeNew();

            Total += 1;
        }
        
        if (currentAmount >= maxAmount)
        {
            for (int i = 0; i < Lines.Count; i++)
            {
                if (i > maxAmount)
                {
                    Destroy(Lines[i].gameObject);
                    Lines.Remove(Lines[i]);
                }
            }
        }

        currentAmount = Lines.Count;
    }

    public void eraseTimeline(GameObject _TLine)
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

        currentAmount = Lines.Count;

        NV.makeNew();
    }
}
