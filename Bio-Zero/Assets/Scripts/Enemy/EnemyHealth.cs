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
        [SerializeField] private GameObject canDropKey;
        [SerializeField] private GameObject key;
        private int powerUpProbability = 25;
        private int keyProbability = 100;
        // Start is called before the first frame update
        private void Start() 
        {   
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
            if(this.gameObject.GetComponent<barrackScript>())
            {
                powerUpProbability = 50;
            }
            
            int randInd = Random.Range(0,100);
            //GameObject powerUp = Instantiate(fireBall, spherePos.position, spherePos.rotation);
            if(randInd < powerUpProbability)
            {
                int randomIndex = Random.Range(0, powerUps.Count);
                currentPowerUp = powerUps[randomIndex];
                Instantiate(currentPowerUp, powerUpPosition.position, powerUpPosition.rotation);
            }
            if(canDropKey.GetComponent<BarrackManager>().GetContinue())
            {
                if(randInd < keyProbability)
                {
                    
                    Instantiate(key, powerUpPosition.position, powerUpPosition.rotation);
                }
                canDropKey.GetComponent<BarrackManager>().setContinue(false);
            }
            
            killCounter++;
            lifeBar.GameObject().SetActive(false);
            ps.setKill(1);
            
        }

        public void Destroy()
        {
            Destroy(this.gameObject);
        }
    }
}
