using Player.Info;
using UnityEngine;

namespace Boss
{
    public class Weapon : MonoBehaviour
    {
        private int damageFirstPhase;
        private int damageSecondPhase;

        public BossAIMovement boss;
        public CharacterHealth playerHealth;
    
        public void Start()
        {
            damageFirstPhase = 10;
            damageSecondPhase = 20;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (playerHealth.getHealth() > 0) //If player is alive
            {
                if (other.CompareTag("Player")) //If Object Collider is a player
                {
                    switch (boss.getPhase()) //Switch for different damage to take
                    {
                        case 1: playerHealth.TakeDamage(damageFirstPhase);
                            break;
                    
                        case 2: playerHealth.TakeDamage(damageSecondPhase);
                            break;
                    }
                }
            }

            else
            {
                Debug.Log("Stronzo sei morto!");
            }
        }
    }
}
