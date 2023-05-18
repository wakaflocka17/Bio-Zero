using Player.Info;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        [HideInInspector] public float health;
        [SerializeField] public Slider lifeBar;
        Animator animator;
        private int killCounter;
        public PlayerInfoManager ps;
        // Start is called before the first frame update
        private void Start() 
        {
            health = 100;
            lifeBar.value = health;
            lifeBar.GameObject().SetActive(true);
            animator= GetComponent<Animator>(); 
        }

        public int getKillCounter()
        {
            return killCounter;
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
            ps.setKill(1);
            lifeBar.GameObject().SetActive(false);
            killCounter += 1;
        }
    }
}
