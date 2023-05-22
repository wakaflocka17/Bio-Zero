using Player.Info;
using UnityEngine;
using System.Collections.Generic;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] public List<GameObject> powerUps;
        private int killCounter;
        [HideInInspector] public float health;
        Animator animator;
        [SerializeField] private Transform powerUpPosition;
        public PlayerInfoManager ps;
        private GameObject currentPowerUp;
        // Start is called before the first frame update
        private void Start() 
        {
            health = 100;
            animator= GetComponent<Animator>(); 
        }


        public void TakeDamage(float damage)
        {
            if(health > 0)
            {
                health -= damage;
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
            ps.setKill(1);
        }
    }
}
