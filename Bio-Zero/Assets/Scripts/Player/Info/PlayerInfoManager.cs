using System;
using DataManager;
using DataManager.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player.Info
{
    public class PlayerInfoManager : MonoBehaviour, InterfaceDataManager
    {
        private int nLevelCounter = 1;
        private DataManager.DataManager dataManager;
    
        [Header("Info Player")]
        public CharacterHealth statsLifePlayer;
        public GameObject playerPosition;
    
        [Header("Info Gameplay Player")]
        private TimeSpan gameplayTimer;
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

            dataManager = GameObject.FindWithTag("DataManager").GetComponent<DataManager.DataManager>();
            
            setNickname(dataManager.GetNickname());
        }

        // Update is called once per frame
        void Update()
        {
            timerInit += Time.deltaTime;
            setTimer(timerInit);
        }

        public void setTimer(float timerToPass)
        {
            gameplayTimer = TimeSpan.FromSeconds(timerToPass);

            timer.text = $"{gameplayTimer.Hours:D2}:{gameplayTimer.Minutes:D2}.<size=42.21>{gameplayTimer.Seconds:D2}";
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
            playerPosition.transform.position = infoPlayer.coordPlayer;

            nKill = infoPlayer.numberKill;
            nLevel = infoPlayer.numberLevel;
        
            gameplayTimer = TimeSpan.FromSeconds(timerInit);

            statsLifePlayer.health = infoPlayer.healthPlayer;
            statsLifePlayer.shield = infoPlayer.shieldPlayer;
        }
    
        public void SaveData(ref InfoGameData infoPlayer)
        {
            infoPlayer.nickname = nickname;

            infoPlayer.coordPlayer = playerPosition.transform.position;

            infoPlayer.healthPlayer = statsLifePlayer.health;
            infoPlayer.shieldPlayer = statsLifePlayer.shield;

            infoPlayer.numberKill = nKill;
            infoPlayer.numberLevel = nLevel;

            infoPlayer.hours = gameplayTimer.Hours;
            infoPlayer.minutes = gameplayTimer.Minutes;
            infoPlayer.seconds = gameplayTimer.Seconds;
        }
    
    
    }
}
