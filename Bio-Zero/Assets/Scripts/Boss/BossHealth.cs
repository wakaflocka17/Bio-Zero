using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float health;
    private Animator bossAnimator;

    private int nPhase; //Start from one to three
    private bool firstAccess;

    // Start is called before the first frame update
    private void Start()
    {
        firstAccess = false;
        nPhase = 1;
        health = 50;
        bossAnimator = GetComponent<Animator>(); 
    }

    public void TakeDamage(float damage)
    {
        //The Switch manages the level of the enemy
        switch (nPhase)
        {
            case 1: 
                if(health > 0)
                {
                    health -= damage;
                    if (health <= 0)
                    {
                        bossPowerUp();
                        nPhase++;
                    }
                }
                
                break;
            
            case 2:

                if (firstAccess == true)
                {
                    firstAccess = false;
                    health = 100;
                }
                
                if(health > 0)
                {
                    health -= damage;
                    if(health <= 0)
                        BossDeath();
                }
                
                break;
        }

    }

    // Second stage for setup boss power up
    public void bossPowerUp()
    {
        bossAnimator.SetBool("isLevelUp", true);
        firstAccess = true;
    }
    
    // I've used this function for setup boss dead
    public void BossDeath()
    {
        bossAnimator.SetBool("isDead", true);
    }

    public int getNPhase()
    {
        return this.nPhase;
    }
    
}
