using Player.Info;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] public List<GameObject> powerUps;
        private int killCounter;
        [SerializeField] public float health;
        Animator animator;
        [SerializeField] private Slider lifeBar;
        [SerializeField] private Transform powerUpPosition;
        public PlayerInfoManager ps;
        private GameObject currentPowerUp;
        // Start is called before the first frame update
        private void Start() 
        {
            if(this.gameObject.GetComponent<NestScript>())
            {
                health = health;
            }
            else
            {
                health = 100;
            }
            
            animator= GetComponent<Animator>();
            lifeBar.value = health;
            lifeBar.GameObject().SetActive(true);
        }


        public void TakeDamage(float damage)
        {
            if(health > 0)
            {
                health -= damage;
                lifeBar.value -= damage;
                
                if(health <= 0)
                    EnemyDeath();
            }
        
        }

        // Update is called once per frame
        public void EnemyDeath()
        {
            int randInd = Random.Range(0,100);
            //GameObject powerUp = Instantiate(fireBall, spherePos.position, spherePos.rotation);
            if(randInd < 80)
            {
                int randomIndex = Random.Range(0, powerUps.Count);
                currentPowerUp = powerUps[randomIndex];
                Instantiate(currentPowerUp, powerUpPosition.position, powerUpPosition.rotation);
            }
            killCounter++;
            lifeBar.GameObject().SetActive(false);
            ps.setKill(1);
        }
    }
}
