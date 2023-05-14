using Player.Info;
using UnityEngine;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [HideInInspector] public float health;
        Animator animator;
        public PlayerInfoManager ps;
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
            ps.setKill(1);
        }
    }
}
