using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace HUD.Menu
{
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
        public SceneLoader sceneM;
    
        public GameObject buttonLoadGame;
        
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

        public void StartNewGame()
        {
            DataManager.DataManager.instance.LoadGame(insertNickname.text);
            sceneM.ChangeScene(1);
        }

        public void LoadOldGame(TextMeshProUGUI nicknameTextField)
        {
            DataManager.DataManager.instance.LoadGame(nicknameTextField.text);
            int idLevel = DataManager.DataManager.instance.GetPlayer().numberLevel;
            
            sceneM.ChangeScene(idLevel);
        }

        public void SetNickname()
        {
            nickname = insertNickname.text;
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
}
