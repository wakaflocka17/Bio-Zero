using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    [SerializeField] public float health;
    Animator bossAnimator;
    
    // Start is called before the first frame update
    private void Start() 
    {
        health = 50;
        bossAnimator = GetComponent<Animator>(); 
    }

    public void TakeDamage(float damage)
    {
        if(health > 0)
        {
            health -= damage;
            if(health <= 0)
                BossDeath();
        }
        
    }

    // Update is called once per frame
    public void BossDeath()
    {
        bossAnimator.SetBool("isDead", true);
    }
    
}
