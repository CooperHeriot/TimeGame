using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignMusicToMusicTrigger : MonoBehaviour
{
    public triggerOnTouch t1, t2;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        t1.theThing = GameObject.Find("Music");
        t2.theThing = GameObject.Find("TutorialParaEnemy");
    }
}
