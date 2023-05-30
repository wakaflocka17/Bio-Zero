using System;
using DataManager;
using DataManager.Data;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        private int hours;
        private int minutes;
        private int seconds;

        [Header("TextMeshProUGUI Player Info")]
        public TextMeshProUGUI nicknameText;
        public TextMeshProUGUI timer;
        public TextMeshProUGUI level;
        public TextMeshProUGUI kill;

        [Header("Cheats Toogle")]
        [SerializeField] public CheatsManager cheatController;

        // Start is called before the first frame update
        void Start()
        {
            dataManager = GameObject.FindWithTag("DataManager").GetComponent<DataManager.DataManager>();
            
            kill.text = DataManager.DataManager.instance.GetPlayer().numberKill.ToString();
            level.text = SceneManager.GetActiveScene().buildIndex.ToString();

            hours = DataManager.DataManager.instance.GetPlayer().hours;
            minutes = DataManager.DataManager.instance.GetPlayer().minutes;
            seconds = DataManager.DataManager.instance.GetPlayer().seconds;

            if (hours == 0.0f && minutes == 0.0f && seconds == 0.0f)
            {
                timerInit = 0f; //Timer init to zero
            }
            else
            {
                timerInit = hours * 3600f + minutes * 60f + seconds;
            }
            
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
            kill.text = nKill.ToString();
            
            nLevel = infoPlayer.numberLevel;
            level.text = nLevel.ToString();

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
            infoPlayer.numberLevel = int.Parse(level.text);

            infoPlayer.hours = gameplayTimer.Hours;
            infoPlayer.minutes = gameplayTimer.Minutes;
            infoPlayer.seconds = gameplayTimer.Seconds;
        }

    }
}
