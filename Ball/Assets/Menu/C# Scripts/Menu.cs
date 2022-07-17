using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            QuitGame();
        }
    }
    public void PlayTopGame()
    {
        SceneManager.LoadScene("OnTopGame");
    }
    public void PlaySideGame()
    {
        SceneManager.LoadScene("OnSideGame");
    }
    public void PlayTwoBricks()
    {
        SceneManager.LoadScene("TwoBricks");
    }
    public void Settings()
    {
        SceneManager.LoadScene("OptionsMenu");
    }
    public void Back2Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}