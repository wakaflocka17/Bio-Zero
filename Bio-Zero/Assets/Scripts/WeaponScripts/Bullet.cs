using Boss;
using Enemy;
using UnityEngine;

namespace WeaponScripts
{
    public class Bullet : MonoBehaviour
    {
    
        [SerializeField] float timeToDestroy;
        [HideInInspector] public WeaponManager weapon;
        // Start is called before the first frame update
        void Start()
        {
            Destroy(this.gameObject, timeToDestroy);
        }

        // Update is called once per frame

        private void OnCollisionEnter(Collision other) {
            if(other.gameObject.GetComponentInParent<EnemyHealth>())
            {
                EnemyHealth enemyHealth = other.gameObject.GetComponentInParent<EnemyHealth>();
                enemyHealth.TakeDamage(weapon.damage);
            
            }
        
            else if (other.gameObject.GetComponentInParent<BossHealth>())
            {
                BossHealth bossHealth = other.gameObject.GetComponentInParent<BossHealth>();
                bossHealth.TakeDamage(weapon.damage);
            }
        
            Destroy(this.gameObject);
        }

    
    }
}
