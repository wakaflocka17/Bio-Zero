using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Info;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float timeToDestroy;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
            
            if(other.gameObject.GetComponent<CharacterHealth>())
            {
                print("pollo3");
                CharacterHealth playerHealth = other.gameObject.GetComponentInParent<CharacterHealth>();
                playerHealth.TakeDamage(10);
            }
        
            Destroy(this.gameObject);
        }
}
