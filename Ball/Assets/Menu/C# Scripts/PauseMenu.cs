using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject MidLine;
    
    public void Start()
    {
        pauseMenu.SetActive(false);
        MidLine.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            pausegame();
        }
    }
    public void pausegame()
    {
        pauseMenu.SetActive(true);
        MidLine.SetActive(false);
        Time.timeScale = 0f;
    }
    public void resumegame()
    {
        pauseMenu.SetActive(false);
        MidLine.SetActive(true);
        Time.timeScale = 1;
    }
    public void mainmenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
}