using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Toggle = UnityEngine.UI.Toggle;

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
        public GameObject chooseLevelMenu;

        [Header("Button Actions")] 
        public GameObject buttonStartGame;
        public TextMeshProUGUI insertNickname;
        public SceneLoader sceneM;

        [Header("Toggle Level")] 
        private int levelChoose;
        public Toggle isActiveFirst;
        public Toggle isActiveSecond;
        public Toggle isActiveThird;
        public TextMeshProUGUI insertNicknameLevelChoose;
        
        public void Start()
        {
            levelChoose = 1;
            Time.timeScale = 1f;
            newGameMenu.SetActive(false);
            loadGameMenu.SetActive(false);
            chooseLevelMenu.SetActive(false);
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

        public void StartGameFromLevelChoose()
        {
            DataManager.DataManager.instance.LoadGame(insertNicknameLevelChoose.text);
            sceneM.ChangeScene(levelChoose);
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
            newGameMenu.SetActive(false);
            loadGameMenu.SetActive(true);
            chooseLevelMenu.SetActive(false);
            optionsMenu.SetActive(false);
            infoMenu.SetActive(false);
        }

        public void ChooseLevel()
        {
            newGameMenu.SetActive(false);
            loadGameMenu.SetActive(false);
            chooseLevelMenu.SetActive(true);
            optionsMenu.SetActive(false);
            infoMenu.SetActive(false);
        }

        public void Options()
        {
            newGameMenu.SetActive(false);
            loadGameMenu.SetActive(false);
            chooseLevelMenu.SetActive(false);
            optionsMenu.SetActive(true);
            infoMenu.SetActive(false);
        }

        public void Info()
        {
            newGameMenu.SetActive(false);
            loadGameMenu.SetActive(false);
            chooseLevelMenu.SetActive(false);
            optionsMenu.SetActive(false);
            infoMenu.SetActive(true);
        }

        public void CloseMenu()
        {
            newGameMenu.SetActive(false);
            //Add feature for reset input type
            insertNickname.text = "";
            chooseLevelMenu.SetActive(false);
            loadGameMenu.SetActive(false);
            optionsMenu.SetActive(false);
            infoMenu.SetActive(false);
        }
        
        public void firstLevelRadioMethod()
        {
            levelChoose = 1;
        }
    
        public void secondLevelRadioMethod()
        {
            levelChoose = 2;
        }
    
        public void thirdLevelRadioMethod()
        {
            levelChoose = 3;
        }
    }
}
