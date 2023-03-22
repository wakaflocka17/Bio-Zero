using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public float health;
    Animator animator;
    // Start is called before the first frame update
    private void Start() 
    {
        health = 20;
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
    }
}
