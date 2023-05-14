using Player.Info;
using UnityEngine;

namespace Boss.FireBallScript
{
    public class FireBall : MonoBehaviour
    {
    
        [SerializeField] float timeToDestroy;
        [HideInInspector] public AxeManager axe;
        // Start is called before the first frame update
        void Start()
        {
            Destroy(this.gameObject, timeToDestroy);
        }

        // Update is called once per frame

        private void OnCollisionEnter(Collision other) {
        
            if(other.gameObject.GetComponentInParent<CharacterHealth>())
            {
                CharacterHealth playerHealth = other.gameObject.GetComponentInParent<CharacterHealth>();
                playerHealth.TakeDamage(axe.damage);
            }

            Destroy(this.gameObject);
        }

    
    }
}