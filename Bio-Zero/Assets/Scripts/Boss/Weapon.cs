using Player.Info;
using UnityEngine;

namespace Boss
{
    public class Weapon : MonoBehaviour
    {
        private int damage;
        

        public BossAIMovement boss;
        public BossHealth bossHealth;
    
        public void Start()
        {
            damage = 10;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<CharacterHealth>()) //If Object Collider is a player
            {
                CharacterHealth characterHealth = other.gameObject.GetComponent<CharacterHealth>();
                characterHealth.TakeDamage(damage);
            }
        }
    }
}
