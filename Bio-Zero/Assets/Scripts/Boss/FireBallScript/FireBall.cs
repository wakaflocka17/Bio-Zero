using Player.Info;
using UnityEngine;

namespace Boss.FireBallScript
{
    public class FireBall : MonoBehaviour
    {
        
        private Transform playerTarget;
        private Transform spherePos;
        [SerializeField] float timeToDestroy;
        private float damage = 20;
        private float speed = 30f;  // Velocità di movimento della palla di fuoco

        private Rigidbody rb;
        // Start is called before the first frame update
        void Start()
        {
            playerTarget = GameObject.FindWithTag("Player").transform;
            spherePos = GameObject.FindWithTag("SpherePos").transform;
            rb = GetComponent<Rigidbody>();
            Destroy(this.gameObject, timeToDestroy);
        }

        private void Update() 
        {
            Vector3 direction = (playerTarget.position - transform.position).normalized;
            direction.y = 0;
            rb.AddForce(direction * speed);
        }

        // Update is called once per frame

        private void OnCollisionEnter(Collision other) {
        
            if(other.gameObject.GetComponentInParent<CharacterHealth>())
            {
                Debug.Log("colpito");
                CharacterHealth playerHealth = other.gameObject.GetComponentInParent<CharacterHealth>();
                playerHealth.TakeDamage(damage);
                Destroy(this.gameObject);
            }
        }
    }
}