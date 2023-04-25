using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class PlayerInfoManager : MonoBehaviour
{
    private float timerInit;
    private int nLevel;
    private int nKill;
    
    //public TextMeshProUGUI nickname;
    //public TextMeshProUGUI health;
    //public TextMeshProUGUI shield;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI level;
    public TextMeshProUGUI kill;
    
    // Start is called before the first frame update
    void Start()
    {
        timerInit = 0f; //Timer init to zero
        
        nLevel = 0; //Level init to the first level
        setLevel(nLevel);
        
        nKill = 0; //Kill number init to zero
        setKill(nKill);
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
        timer.text = string.Format("{0:D2}:{1:D2}.<size=42.21>{2:D2}", t.Hours, t.Minutes, t.Seconds);
        
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
    
    
}
