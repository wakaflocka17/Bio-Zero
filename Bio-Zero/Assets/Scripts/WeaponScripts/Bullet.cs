using Boss;
using Enemy;
using UnityEngine;
using Player.Info;

namespace WeaponScripts
{
    public class Bullet : MonoBehaviour
    {
    
        [SerializeField] float timeToDestroy;
        [HideInInspector] public WeaponManager weapon;
        // [SerializeField] EnemyShoot enemyShoot;
        // Start is called before the first frame update
        void Start()
        {
            Destroy(this.gameObject, timeToDestroy);
        }

        // Update is called once per frame
        private void OnCollisionEnter(Collision other) {
            if(other.gameObject.GetComponentInParent<EnemyHealth>())
            {
                print("pollo1");
                EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
                enemyHealth.TakeDamage(weapon.damage);
                
            
            }
            else if(other.gameObject.GetComponentInParent<BossHealth>())
            {
                print("pollo2");
                BossHealth bossHealth = other.gameObject.GetComponentInParent<BossHealth>();
                bossHealth.TakeDamage(weapon.damage);
            }
        
            Destroy(this.gameObject);
        }
    }
}
