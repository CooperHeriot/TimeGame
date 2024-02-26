using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string sceneToLoad;
    // Start is called before the first frame update

    public void LoadScene()
    {
        PlayerPrefs.SetInt("point", -1);

        SceneManager.LoadScene(sceneToLoad);
    }
    public void quit()
    {
        PlayerPrefs.SetInt("point", -1);

        Application.Quit();
    }

    public void CHekpoint()
    {
        //PlayerPrefs.SetInt("point", -1);

        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("point", -1);

        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MenuLoad()
    {
        PlayerPrefs.SetInt("point", -1);

        SceneManager.LoadScene("TItle");
        Time.timeScale = 1.0f;
    }
}
