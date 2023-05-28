using System.Collections.Generic;
using System.Linq;
using DataManager.Data;
using UnityEngine;

namespace DataManager
{
    public class DataManager : MonoBehaviour
    {
        [Header("User Input Text")]
        private string nickname = "";

        private InfoGameData infoPlayer;
        private List<InterfaceDataManager> dataObjects;
        private FileDataHandler dataHandler;
    
        public static DataManager instance { get; private set; }
    
        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this);
            }

            else
            {
                instance = this; 
            }
        
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            dataHandler = new FileDataHandler(Application.persistentDataPath, "");
            dataObjects = FindAllDataObjects();
        }

        public void NewGame(string nicknamePlayer)
        {
            infoPlayer = new InfoGameData(nicknamePlayer);
        }

        public InfoGameData GetPlayer()
        {
            return infoPlayer;
        }
    
        public void LoadGame(string nicknamePlayer)
        {
            infoPlayer = dataHandler.Load();
            nickname = nicknamePlayer;

            if (infoPlayer == null)
            {
                NewGame(nicknamePlayer);
                infoPlayer.nickname = nicknamePlayer;
            }
            
            else
            {
                infoPlayer.nickname = nicknamePlayer;
            }

            foreach (InterfaceDataManager singleDataObject in dataObjects)
            {
                singleDataObject.LoadData(infoPlayer);
            }
        }

        public void SaveGame()
        {
            dataObjects = FindAllDataObjects();
            
            foreach (InterfaceDataManager singleDataObject in dataObjects)
            {
                singleDataObject.SaveData(ref infoPlayer);
            }
            
            dataHandler.Save(infoPlayer);

        }

        private List<InterfaceDataManager> FindAllDataObjects()
        {
            IEnumerable<InterfaceDataManager> dataObjectsEnumerable = FindObjectsOfType<MonoBehaviour>()
                .OfType<InterfaceDataManager>();

            return new List<InterfaceDataManager>(dataObjectsEnumerable);
        }

        public string GetNickname()
        {
            return nickname;
        }

    }
}