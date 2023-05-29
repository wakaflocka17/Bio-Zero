using HUD.Menu;
using UnityEngine;
using UnityEngine.UI;

namespace Player.Info
{
    public class CharacterHealth : MonoBehaviour
    {
        public Slider sliderHealth;
        public Slider sliderShield;
        public float health;
        public float shield;
        Animator animator;
        [SerializeField] private PauseMenuManager pauseM;
        [SerializeField] private CheatsManager cheatController;

        // Start is called before the first frame update
        private void Start()
        {
            animator = GetComponent<Animator>();
            health = DataManager.DataManager.instance.GetPlayer().healthPlayer;
            sliderHealth.value = health;
            
            shield = DataManager.DataManager.instance.GetPlayer().shieldPlayer;
            sliderShield.value = shield;
        }

        public float getHealth()
        {
            return this.health;
        }

        public float getShield()
        {
            return this.shield;
        }

        public void TakeDamage(float damage)
        {
            if (!cheatController.cheatNoDamageToggle.isOn)
            {
                if (shield > 0)
                {
                    shield -= damage;
                    sliderShield.value = shield;

                    if (shield < 0)
                    {
                        shield = 0;
                    }
                }

                else if (health > 0)
                {
                    health -= damage;
                    sliderHealth.value = health;

                    if (health <= 0)
                        EnemyDeath();
                }
            }
        }

        public void DisableHitAnimation()
        {
            animator.SetBool("Hit", false);
        }

        public void EnemyDeath()
        {
            animator.SetBool("isDead", true);
            pauseM.DefeatMenu();
        }
        public void DisableDeath()
        {
            animator.SetBool("isDead", false);
        }
    }
}