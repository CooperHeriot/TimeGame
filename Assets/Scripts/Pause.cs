using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject panel;
    public bool paused;
    public string sceneToLoad;

    public float orien;
    [Header("Enable first person mode")]
    public bool FPSMode;
    public TimelineManager TM;

    public float TheTime;
    // Start is called before the first frame update
    void Start()
    {
        TM = GameObject.FindObjectOfType<TimelineManager>();

        if (paused == true)
        {
            panel.SetActive(true);
            Time.timeScale = 0;

            if (FPSMode == true)
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else
        {
            panel.SetActive(false);
            Time.timeScale = TheTime;

            if (FPSMode == true)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
        /*if (panel.gameObject.activeSelf == false)
        {
            Cursor.lockState = CursorLockMode.None;
        }*/

        if (paused == false)
        {
            Time.timeScale = TheTime;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
       
    }

    public void TogglePause()
    {
        paused = !paused;

        if (paused == true)
        {
            panel.SetActive(true);
            if (TM != null)
            {
                Time.timeScale = 0;
            }            

            if (FPSMode == true)
            {
                Cursor.lockState = CursorLockMode.None;
            }
        } else
        {
            panel.SetActive(false);
            Time.timeScale = TheTime;

            if (FPSMode == true)
            {
                if (TM.lsott == false)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                } else
                {
                    Cursor.lockState = CursorLockMode.None;
                }
                
            }
        }
    }

    public void LoadScene()
    {
        PlayerPrefs.SetInt("point", -1);
        Time.timeScale = 1;

        SceneManager.LoadScene(sceneToLoad);
    }

    public void reset()
    {
        PlayerPrefs.SetInt("point", -1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void checkPoint()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void quit()
    {
        PlayerPrefs.SetInt("point", -1);

        Application.Quit();
    }

    public void toggleFullscreen()
    {
        GameObject.FindObjectOfType<CamManager>().ToggleFullscreen();

       // print("rgtfyf");
    }

    public void newPos(float _new)
    {
        orien = _new;

        for (int i = 0; i < FindObjectsOfType<GunOrien>().Length; i++)
        {
            FindObjectsOfType<GunOrien>()[i].GetComponent<GunOrien>().NewPos(orien);
        }

        PlayerPrefs.SetFloat("rien", orien);
    }

    public void ToggleInvert(bool _Inv)
    {
        int innn = 0;

        if (_Inv == true)
        {
            innn = -1;
        } else
        {
            innn = 1;
        }

        PlayerPrefs.SetInt("Inverty", innn);

        print(innn);
    }
}
