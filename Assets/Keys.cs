using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Keys : MonoBehaviour
{
    public string Scene2Load;
    public GameObject W, A, S, D, R, LM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Destroy(W.gameObject);
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Destroy(A.gameObject);
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Destroy(S.gameObject);
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Destroy(D.gameObject);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Destroy(R.gameObject);
        }

        if (Input.GetMouseButton(0))
        {
            Destroy(LM.gameObject);
        }

        if (W == null && A == null && S == null && D == null && R == null && LM == null)
        {
            SceneManager.LoadScene(Scene2Load);
        }
    }
}
