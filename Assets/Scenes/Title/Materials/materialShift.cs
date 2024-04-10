using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class materialShift : MonoBehaviour
{
    public Material ren;

    public float thinger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ren.SetTextureOffset("_MainTex",new Vector2(0, thinger * Time.deltaTime));
        ren.mainTextureOffset += new Vector2(0, thinger * Time.deltaTime);
    }
}
