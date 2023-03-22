using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    GameObject character;
    [SerializeField] public float health;
    Animator animator;
    // Start is called before the first frame update
    private void Start() 
    {
        character = GetComponent<GameObject>();
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        animator.SetBool("Hit", true);
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
        animator.SetBool("isDead", true);
        
    }
    void DisableDeath()
    {
        animator.SetBool("isDead", false);
    }
}
