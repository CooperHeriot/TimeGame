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
        SceneManager.LoadScene(sceneToLoad);
    }
    public void quit()
    {
        Application.Quit();
    }

    public void Reset()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MenuLoad()
    {
        SceneManager.LoadScene("TItle");
        Time.timeScale = 1.0f;
    }
}
