using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestoyonLoad : MonoBehaviour
{
    private static GameObject instance;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
            instance = gameObject;
        else
            Destroy(gameObject);
    }
}
