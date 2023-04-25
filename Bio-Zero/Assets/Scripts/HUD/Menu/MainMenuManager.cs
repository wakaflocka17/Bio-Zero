using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [Header("PopUp Menu")]
    public GameObject newGameMenu;
    public GameObject loadGameMenu;
    public GameObject optionsMenu;
    public GameObject infoMenu;
    
    public void Start()
    {
        Time.timeScale = 1f;
        newGameMenu.SetActive(false);
        loadGameMenu.SetActive(false);
        optionsMenu.SetActive(false);
        infoMenu.SetActive(false);
    }

    public void NewGame()
    {
        newGameMenu.SetActive(true);
    }

    public void LoadGame()
    {
        loadGameMenu.SetActive(true);
    }

    public void Options()
    {
        optionsMenu.SetActive(true);
    }

    public void Info()
    {
        infoMenu.SetActive(true);
    }

    public void CloseMenu()
    {
        newGameMenu.SetActive(false);
        loadGameMenu.SetActive(false);
        optionsMenu.SetActive(false);
        infoMenu.SetActive(false);
    }
}
