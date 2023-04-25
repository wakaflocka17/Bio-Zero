using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    public Slider sliderHealth;
    public Slider sliderShield;
    [SerializeField] public float health;
    [SerializeField] public float shield;
    Animator animator;
    // Start is called before the first frame update
    private void Start() 
    {
        animator = GetComponent<Animator>();
    }

    public float getHealth()
    {
        return this.health;
    }

    public float getShield()
    {
        return this.shield;
    }

    public void TakeDamage(float damage)
    {
        animator.SetBool("Hit", true);
        
        if(shield > 0)
        {
            shield -= damage;
            sliderShield.value = shield;
            
            if(shield < 0)
            {
                shield = 0;
            }
        }
        
        else if(health > 0)
        {
            health -= damage;
            sliderHealth.value = health;
            
            if(health <= 0)
                EnemyDeath();
        }

    }

    public void DisableHitAnimation()
    {
        animator.SetBool("Hit", false);
    }

    public void EnemyDeath()
    {
        animator.SetBool("isDead", true);

    }
    public void DisableDeath()
    {
        animator.SetBool("isDead", false);
    }
}