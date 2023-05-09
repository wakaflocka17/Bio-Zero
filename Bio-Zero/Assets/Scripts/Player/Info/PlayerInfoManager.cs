using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class PlayerInfoManager : MonoBehaviour, InterfaceDataManager
{
    private int nLevelCounter = 1;
    
    [Header("Info Player")]
    public CharacterHealth statsLifePlayer;
    public Transform playerPosition;
    
    [Header("Info Gameplay Player")]
    private InfoGameData.TimePlayer timeGamePlay;
    private int nLevel;
    private int nKill;
    private string nickname;
    private float timerInit;

    [Header("TextMeshProUGUI Player Info")]
    public TextMeshProUGUI nicknameText;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI level;
    public TextMeshProUGUI kill;
    
    // Start is called before the first frame update
    void Start()
    {
        timerInit = 0f; //Timer init to zero
        
        nLevel = 0; //Level init to the first level
        setLevel(nLevelCounter);
        
        nKill = 0; //Kill number init to zero
        setKill(nKill);

        nickname = "Wakaflocka17";
        setNickname(nickname);
    }

    // Update is called once per frame
    void Update()
    {
        timerInit += Time.deltaTime;
        setTimer(timerInit);
    }

    /*public void setNickname(String nicknameToPass)
    {
        nickname.text = nicknameToPass;
    }*/

    public void setTimer(float timerToPass)
    {
        
        TimeSpan t = TimeSpan.FromSeconds(timerToPass);
        
        timeGamePlay.hours = t.Hours;
        timeGamePlay.minutes = t.Hours;
        timeGamePlay.seconds = t.Hours;
        
        timer.text = string.Format("{0:D2}:{1:D2}.<size=42.21>{2:D2}", t.Hours, t.Minutes, t.Seconds);
        
    }

    public void setNickname(string nickname)
    {
        this.nickname = nickname;
        nicknameText.text = this.nickname;
    }
    
    public void setLevel(int levelToPass)
    {
        nLevel += levelToPass;
        level.text = nLevel.ToString();
    }
    
    public void setKill(int killToPass)
    {
        if (killToPass == 0)
        {
            nKill = killToPass;
        }
        
        else
        {
            nKill += killToPass;
        }
        
        kill.text = nKill.ToString();
    }

    public void LoadData(InfoGameData infoPlayer)
    {
        this.playerPosition.position = infoPlayer.coordPlayer;
        this.nKill = infoPlayer.numberKill;
        this.nLevel = infoPlayer.numberLevel;
        this.timeGamePlay = infoPlayer.timePlayer;
        this.statsLifePlayer.health = infoPlayer.statsLifePlayer.health;
        this.statsLifePlayer.shield = infoPlayer.statsLifePlayer.shield;
    }
    
    public void SaveData(ref InfoGameData infoPlayer)
    {
        infoPlayer.coordPlayer = this.playerPosition.position;
        infoPlayer.numberKill = this.nKill;
        infoPlayer.numberLevel = this.nLevel;
        infoPlayer.timePlayer = this.timeGamePlay;
        infoPlayer.statsLifePlayer.health = this.statsLifePlayer.health;
        infoPlayer.statsLifePlayer.shield = this.statsLifePlayer.shield;
    }
    
    
}
