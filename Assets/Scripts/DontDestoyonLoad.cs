using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestoyonLoad : MonoBehaviour
{
    private static GameObject instance;

    public int ID;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (instance == null)
            instance = gameObject;
        else
            Destroy(gameObject);

        if (SceneManager.GetActiveScene().buildIndex != ID)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != ID)
        {
            Destroy(gameObject);
        }
    }
}
