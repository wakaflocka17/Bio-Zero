using Player.Info;
using UnityEngine;

namespace Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        public int damage = 20;
    
        private void OnTriggerEnter(Collider other) 
        {
            if(other.gameObject.GetComponent<CharacterHealth>())
            {
                CharacterHealth characterHealth = other.gameObject.GetComponent<CharacterHealth>();
                characterHealth.TakeDamage(damage);
            
            }
        
        }
    
    }
}
