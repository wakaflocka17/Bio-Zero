using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    GameObject character;
    public Slider slider;
    [SerializeField] public float health;
    Animator animator;
    // Start is called before the first frame update
    private void Start() 
    {
        character = GetComponent<GameObject>();
        animator = GetComponent<Animator>();
    }

    public float getHealth()
    {
        return this.health;
    }

    public void TakeDamage(float damage)
    {
        animator.SetBool("Hit", true);
        if(health > 0)
        {
            health -= damage;
            slider.value = health;
            if(health <= 0)
                EnemyDeath();
        }
        
    }

    public void DisableHitAnimation()
    {
        animator.SetBool("Hit", false);
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
