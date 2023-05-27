using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

namespace Boss
{
    public class BossHealth : MonoBehaviour
    {
        public float health;
        private Animator bossAnimator;
        [SerializeField] private Slider lifeBar;
        private float startHealth;

        private int nPhase; //Start from one to three

        // Start is called before the first frame update
        private void Start()
        {
            startHealth = health;
            lifeBar.value = health;
            lifeBar.GameObject().SetActive(true);
            nPhase = 1;
            health = 50;
            bossAnimator = GetComponent<Animator>(); 
        }

        public void TakeDamage(float damage)
        {
            //The Switch manages the level of the enemy
            switch (nPhase)
            {
                case 1: 
                    if(health > 0)
                    {
                        lifeBar.value -= damage;
                        health -= damage;
                        if (health <= 0)
                        {
                            bossPowerUp();
                            nPhase++;
                        }
                    }
                    break;
                case 2:

                    if(health > 0)
                    {
                        lifeBar.value -= damage;
                        health -= damage;
                        if(health <= 0)
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
            lifeBar.GameObject().SetActive(false);
            bossAnimator.SetBool("isDead", true);
        }

        public int getNPhase()
        {
            return this.nPhase;
        }
    
    }
}
