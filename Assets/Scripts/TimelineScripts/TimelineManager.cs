using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineManager : MonoBehaviour
{
    public float maxAmount, currentAmount = 1, offset = 100;

    public List<GameObject> Lines = new List<GameObject>();
    public GameObject primeTime;
    // Start is called before the first frame update
    void Start()
    {
        Lines.Add(primeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createNewTimeline(GameObject _TLine)
    {
        GameObject NewTL = Instantiate(_TLine, new Vector3(primeTime.transform.position.x + (offset * currentAmount),0, primeTime.transform.position.z + (offset * currentAmount)),transform.rotation, transform);
        Lines.Add(_TLine);
    }

    public void eraseTimeline(GameObject _TLine)
    {
        Destroy(_TLine.gameObject);
        Lines.Remove(_TLine);
    }
}
