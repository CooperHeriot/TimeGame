using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHoleFlip : MonoBehaviour
{
    private SpriteRenderer SR;

    private float ex, wy;
    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();

        ex = Random.Range(0, 10);
        wy = Random.Range(0, 10);

        if (ex >= 5)
        {
            SR.flipX = true;
        } else
        {
            SR.flipX = false;
        }

        if (wy >= 5)
        {
            SR.flipY = true;
        }
        else
        {
            SR.flipY = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
