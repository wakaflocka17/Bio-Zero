using Cinemachine;
using Player.AimStates;
using UnityEngine;

namespace HUD.Menu
{
    public class PauseMenuManager : MonoBehaviour
    {
        private bool buttonPressed;
        public GameObject buttonSave;
        public SettingsManager settingsM;
        public GameObject pauseMenu;
        public GameObject saveProgressMenu;
        public GameObject confirmSaveText;
        public GameObject saveAlertText;
        public GameObject optionsMenu;
        public GameObject buttonPause;
        public GameObject buttonPlay;
        public CinemachineBrain cameraGame;
        public CharacterController mouseController;

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
            saveAlertText.SetActive(false);
            buttonPause.SetActive(false);
            optionsMenu.SetActive(false);
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
            pauseMenu.SetActive(false);
            optionsMenu.SetActive(false);
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
            pauseMenu.SetActive(false);
            saveProgressMenu.SetActive(false);
            optionsMenu.SetActive(true);
        }

        public void GoToSaveGame()
        {
            pauseMenu.SetActive(false);
            optionsMenu.SetActive(false);
            saveProgressMenu.SetActive(true);
            buttonSave.SetActive(true);
            confirmSaveText.SetActive(true);
        }

        public void PressedButtonSave()
        {
            DataManager.DataManager.instance.SaveGame();
            buttonSave.SetActive(false);
            confirmSaveText.SetActive(false);
            saveAlertText.SetActive(true);
        }

    }
}
