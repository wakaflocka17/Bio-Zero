using HUD.Menu;
using Player.Info;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Boss
{
    public class BossHealth : MonoBehaviour
    {
        private Animator bossAnimator;
        [SerializeField] private Slider lifeBar;
        private float startHealth;
        public float health;
        private int nPhase;
        [SerializeField] public PauseMenuManager pauseMenu; //Start from one to three
        [SerializeField] public PlayerInfoManager playerM;
        [SerializeField] public CheatsManager cheatController;
        
        // Start is called before the first frame update
        private void Start()
        {
            startHealth = health;
            lifeBar.value = health;
            lifeBar.GameObject().SetActive(true);
            nPhase = 1;
            bossAnimator = GetComponent<Animator>(); 
            lifeBar.value = health;
            lifeBar.GameObject().SetActive(true);
        }

        public void TakeDamage(float damage)
        {
            //The Switch manages the level of the enemy
                switch (nPhase)
                {
                    case 1:
                        
                        if (!cheatController.cheatOSKToggle.isOn)
                        {
                            if (health > 0)
                            {
                                lifeBar.value -= damage;
                                health -= damage;
                                if (health <= 0)
                                {
                                    bossPowerUp();
                                    nPhase++;
                                }
                            }
                        }

                        else
                        {
                            health -= health;
                            lifeBar.value -= health;
                            bossPowerUp();
                            nPhase++;
                        }

                        break;

                    case 2:

                        if (!cheatController.cheatOSKToggle.isOn)
                        {
                            if (health > 0)
                            {
                                lifeBar.value -= damage;
                                health -= damage;

                                if (health <= 0)
                                    BossDeath();
                            }
                        }

                        else
                        {
                            health -= health;
                            lifeBar.value -= health;
                            BossDeath();
                        }

                        break;
                }

        }

        // Second stage for setup boss power up
        public void bossPowerUp()
        {
            lifeBar.value = startHealth;
            health = startHealth;
            bossAnimator.SetTrigger("isLevelUp");
            
        }
    
        // I've used this function for setup boss dead
        public void BossDeath()
        {
            DataManager.DataManager.instance.GetPlayer().numberKill += 1;
            playerM.setKill(1);

            int level = SceneManager.GetActiveScene().buildIndex + 1;
            
            lifeBar.GameObject().SetActive(false);
            bossAnimator.SetBool("isDead", true);

            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                Debug.Log("Ora cambio scena!");
                DataManager.DataManager.instance.SaveGame();
                pauseMenu.sceneM.ChangeScene(level);
            }
        }

        public int getNPhase()
        {
            return this.nPhase;
        }
    
    }
}
