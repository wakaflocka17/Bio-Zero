using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    private bool buttonPressed;
    public GameObject pauseMenu;
    public GameObject saveProgressMenu;
    public GameObject optionsMenu;
    public GameObject buttonPause;
    public GameObject buttonPlay;

    public void Start()
    {
        Time.timeScale = 1f;
        buttonPressed = false;
        buttonPause.SetActive(true);
        buttonPlay.SetActive(false);
        pauseMenu.SetActive(false);
        saveProgressMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && buttonPressed == false) 
        {
            Pause();
        }
        
        else if (Input.GetKeyDown(KeyCode.Escape) && buttonPressed)
        {
            Resume();
        }
    }
    
    public void Pause()
    {
        /* Not visible HUD Elements */
        buttonPause.SetActive(false);
        optionsMenu.SetActive(false);
        saveProgressMenu.SetActive(false);
        
        /* Visible HUD Elements */
        buttonPressed = true;
        pauseMenu.SetActive(true);
        buttonPlay.SetActive(true);
        
        /* Stop TimeScale meanwhile user using menù */
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        /* Not visible HUD Elements */
        buttonPressed = false;
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        saveProgressMenu.SetActive(false);
        buttonPlay.SetActive(false);
        
        /* Visible HUD Elements */
        buttonPause.SetActive(true);
        
        /* Starting TimeScale meanwhile user pressing Escape Key */
        Time.timeScale = 1f;
    }

    public void GoToSettings()
    {
        pauseMenu.SetActive(false);
        saveProgressMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void GoToSaveGame()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        saveProgressMenu.SetActive(true);
    }

}
