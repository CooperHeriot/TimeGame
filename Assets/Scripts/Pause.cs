using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject panel;
    public bool paused;
    public string sceneToLoad;

    [Header("Enable first person mode")]
    public bool FPSMode;
    public TimelineManager TM;
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
            Time.timeScale = 1;

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
       
    }

    public void TogglePause()
    {
        paused = !paused;

        if (paused == true)
        {
            panel.SetActive(true);
            Time.timeScale = 0;

            if (FPSMode == true)
            {
                Cursor.lockState = CursorLockMode.None;
            }
        } else
        {
            panel.SetActive(false);
            Time.timeScale = 1;

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
        SceneManager.LoadScene(sceneToLoad);
    }

    public void reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void quit()
    {
        Application.Quit();
    }
}
