using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    private string nickname;
    
    [Header("PopUp Menu")]
    public GameObject newGameMenu;
    public GameObject loadGameMenu;
    public GameObject optionsMenu;
    public GameObject infoMenu;

    [Header("Button Actions")] 
    public GameObject buttonStartGame;
    public TextMeshProUGUI insertNickname;
    
    public GameObject buttonLoadGame;

    public void Start()
    {
        Time.timeScale = 1f;
        newGameMenu.SetActive(false);
        loadGameMenu.SetActive(false);
        optionsMenu.SetActive(false);
        infoMenu.SetActive(false);
    }

    public void Update()
    {
        this.nickname = insertNickname.text;
    }

    public void NewGame()
    {
        newGameMenu.SetActive(true);
    }

    public void StartNewGame()
    {
        DataManager.instance.LoadGame(insertNickname.text);
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
        //Add feature for reset input type
        insertNickname.text = "";
        loadGameMenu.SetActive(false);
        optionsMenu.SetActive(false);
        infoMenu.SetActive(false);
    }
}
