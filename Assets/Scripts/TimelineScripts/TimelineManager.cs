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

    [Header("Game Over")]
    public GameObject GameOver;
    // Start is called before the first frame update
    void Start()
    {
        GameOver.SetActive(false);

        Lines.Add(primeTime);

        primeTime.GetComponent<TimelineBehav>().becomePrime();

        currentAmount = Lines.Count;

        CM = GetComponent<CamManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Lines.Count == 0)
        {
            GameOver.SetActive(true);
        }
    }

    public void createNewTimeline(GameObject _TLine, Sprite _Gunn, float _FRate, bool _Auto, GameObject _Bullet)
    {
        if (currentAmount < maxAmount)
        {
            GameObject NewTL = Instantiate(_TLine, new Vector3(primeTime.transform.position.x + (offset * currentAmount), 0, primeTime.transform.position.z + (offset * currentAmount)), transform.rotation, transform);
            Lines.Add(NewTL);

            CM.Cams.Add(NewTL.GetComponent<TimelineBehav>().Cam);
            NewTL.GetComponent<TimelineBehav>().prime = false;

            NewTL.GetComponent<TimelineBehav>().newGunForPlayer(_Gunn, _FRate, _Auto, _Bullet);
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
        

        Destroy(_TLine.gameObject);
        Lines.Remove(_TLine);

        if (_TLine.GetComponent<TimelineBehav>().prime == true)
        {
            Lines[0].GetComponent<TimelineBehav>().becomePrime();
        }

        CM.Cams.Remove(_TLine.GetComponent<TimelineBehav>().Cam);

        currentAmount = Lines.Count;
    }
}
