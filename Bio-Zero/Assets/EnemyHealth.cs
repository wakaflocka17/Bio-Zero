using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    GameObject enemy;
    [SerializeField] float health;
    // Start is called before the first frame update
    public void TakeDamage(float damage)
    {
        if(health > 0)
        {
            health -= damage;
            if(health <= 0)
                EnemyDeath();
            Debug.Log("Hit");
        }
        
    }

    // Update is called once per frame
    public void EnemyDeath()
    {
        Debug.Log("death");
    }
}
