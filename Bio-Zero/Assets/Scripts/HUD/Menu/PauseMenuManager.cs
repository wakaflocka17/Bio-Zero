using Cinemachine;
using Player.AimStates;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HUD.Menu
{
    public class PauseMenuManager : MonoBehaviour
    {
        private bool buttonPressed;
        public SettingsManager settingsM;
        public GameObject pauseMenu;
        public GameObject saveProgressMenu;
        public GameObject confirmMenu;
        public GameObject defeatMenu;
        public GameObject cheatsMenu;
        public GameObject optionsMenu;
        public GameObject buttonPause;
        public GameObject buttonPlay;
        public CinemachineBrain cameraGame;
        public CharacterController mouseController;

        public SceneLoader sceneM;

        public void Start()
        {
            // For setting cursor position in game
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Screen.fullScreen = true;
            Time.timeScale = 1f;
            cameraGame.enabled = true;
            buttonPressed = false;
            buttonPause.SetActive(true);
            buttonPlay.SetActive(false);
            confirmMenu.SetActive(false);
            defeatMenu.SetActive(false);
            cheatsMenu.SetActive(false);
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
            // For setting cursor position in game
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            /* Not visible HUD Elements */
            buttonPause.SetActive(false);
            confirmMenu.SetActive(false);
            optionsMenu.SetActive(false);
            defeatMenu.SetActive(false);
            cheatsMenu.SetActive(false);
            saveProgressMenu.SetActive(false);
            cameraGame.enabled = false;
            mouseController.enabled = false;
            FindObjectOfType<AimStateManager>().setMouseSense(0);

            /* Visible HUD Elements */
            buttonPressed = true;
            pauseMenu.SetActive(true);
            buttonPlay.SetActive(true);

            /* Stop TimeScale meanwhile user using menù */
            Time.timeScale = 0;
        }

        public void Resume()
        {
            // For setting cursor position in game
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            /* Not visible HUD Elements */
            buttonPressed = false;
            confirmMenu.SetActive(false);
            pauseMenu.SetActive(false);
            defeatMenu.SetActive(false);
            optionsMenu.SetActive(false);
            cheatsMenu.SetActive(false);
            saveProgressMenu.SetActive(false);
            buttonPlay.SetActive(false);

            /* Visible HUD Elements */
            buttonPause.SetActive(true);
            cameraGame.enabled = true;
            mouseController.enabled = true;
            FindObjectOfType<AimStateManager>().setMouseSense(1);

            /* Starting TimeScale meanwhile user pressing Escape Key */
            Time.timeScale = 1f;
        }

        public void GoToSettings()
        {
            confirmMenu.SetActive(false);
            pauseMenu.SetActive(false);
            defeatMenu.SetActive(false);
            saveProgressMenu.SetActive(false);
            cheatsMenu.SetActive(false);
            optionsMenu.SetActive(true);
        }

        public void GoToSaveGame()
        {
            confirmMenu.SetActive(false);
            pauseMenu.SetActive(false);
            defeatMenu.SetActive(false);
            optionsMenu.SetActive(false);
            cheatsMenu.SetActive(false);
            saveProgressMenu.SetActive(true);
        }

        public void ConfirmSaveGame()
        {
            pauseMenu.SetActive(false);
            defeatMenu.SetActive(false);
            optionsMenu.SetActive(false);
            cheatsMenu.SetActive(false);
            saveProgressMenu.SetActive(false);
            confirmMenu.SetActive(true);
        }

        public void GoToCheats()
        {
            pauseMenu.SetActive(false);
            defeatMenu.SetActive(false);
            optionsMenu.SetActive(false);
            saveProgressMenu.SetActive(false);
            cheatsMenu.SetActive(true);
        }

        public void PressedButtonSave()
        {
            DataManager.DataManager.instance.SaveGame();
            Debug.Log("Questo livello è il numero: " + DataManager.DataManager.instance.GetPlayer().numberLevel);
            ConfirmSaveGame();
        }

        public void DefeatMenu()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            pauseMenu.SetActive(false);
            optionsMenu.SetActive(false);
            saveProgressMenu.SetActive(false);
            cheatsMenu.SetActive(false);
            defeatMenu.SetActive(true);
        }

        public void GoToGame()
        {
            int actualLevel = SceneManager.GetActiveScene().buildIndex;
            
            sceneM.ChangeScene(actualLevel);
        }

        public void NextLevel()
        {
            int nextLevel = SceneManager.GetActiveScene().buildIndex;

            //Because 0,1,2,3,4 are Scene on Game
            if (nextLevel < 5)
            {
                nextLevel += 1;
                DataManager.DataManager.instance.GetPlayer().numberLevel += 1;
                DataManager.DataManager.instance.SaveGame();
            }

            sceneM.ChangeScene(nextLevel);
        }

    }
}
