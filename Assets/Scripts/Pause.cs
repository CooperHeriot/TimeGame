using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject panel;
    public GameObject settings;
    public bool paused;
    public string sceneToLoad;

    public float orien;
    [Header("Enable first person mode")]
    public bool FPSMode;
    public TimelineManager TM;

    public float TheTime;

    public GameObject first, optionsfirst, optionslast;
    public AudioMixer Mix;
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
            settings.SetActive(false);
            Time.timeScale = TheTime;

            if (FPSMode == true)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        Mix.SetFloat("SV", PlayerPrefs.GetFloat("SFXv"));
        Mix.SetFloat("MV", PlayerPrefs.GetFloat("MUSv"));
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
            EventSystem.current.SetSelectedGameObject(first);
        } else
        {
            panel.SetActive(false);
            settings.SetActive(false);
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

    public void Setoptions()
    {
        EventSystem.current.SetSelectedGameObject(optionsfirst);
    }
    public void SetOptionsLast()
    {
        EventSystem.current.SetSelectedGameObject(optionslast);
    }
    public void SetFirst()
    {
        EventSystem.current.SetSelectedGameObject(first);
    }

    public void newSFX(float _new)
    {
        Mix.SetFloat("SV", _new);
        PlayerPrefs.SetFloat("SFXv", _new);
    }
    public void newMUS(float _new)
    {
        Mix.SetFloat("MV", _new);
        PlayerPrefs.SetFloat("MUSv", _new);
    }
}
