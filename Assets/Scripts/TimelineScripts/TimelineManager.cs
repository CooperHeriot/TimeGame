using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineManager : MonoBehaviour
{
    public float maxAmount, currentAmount = 1, offset = 30;

    public List<GameObject> Lines = new List<GameObject>();
    public GameObject primeTime;

    public Quaternion primmeRot;
    // Start is called before the first frame update
    void Start()
    {
        Lines.Add(primeTime);

        currentAmount = Lines.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createNewTimeline(GameObject _TLine)
    {
        if (currentAmount < maxAmount)
        {
            GameObject NewTL = Instantiate(_TLine, new Vector3(primeTime.transform.position.x + (offset * currentAmount), 0, primeTime.transform.position.z + (offset * currentAmount)), transform.rotation, transform);
            Lines.Add(NewTL);
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

        currentAmount = Lines.Count;
    }
}
