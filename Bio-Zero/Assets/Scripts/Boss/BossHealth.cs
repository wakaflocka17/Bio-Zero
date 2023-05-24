using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Boss
{
    public class BossHealth : MonoBehaviour
    {
        private Animator bossAnimator;
        [SerializeField] private Slider lifeBar;
        
        public float health;

        private int nPhase; //Start from one to three

        // Start is called before the first frame update
        private void Start()
        {
            nPhase = 1;
            health = 100;
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
                    if(health > 0)
                    {
                        health -= damage;
                        lifeBar.value -= damage;
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
                        health -= damage;
                        lifeBar.value -= damage;
                        Debug.Log("La lifebar vale:" + lifeBar.value);
                        if(health <= 0)
                            BossDeath();
                    }
                    break;
            }

        }

        // Second stage for setup boss power up
        public void bossPowerUp()
        {
            health = 100;
            lifeBar.value = health;
            bossAnimator.SetTrigger("isLevelUp");
            
        }
    
        // I've used this function for setup boss dead
        public void BossDeath()
        {
            bossAnimator.SetBool("isDead", true);
        }

        public int getNPhase()
        {
            return this.nPhase;
        }
    
    }
}
