using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.GetComponent<CharacterHealth>())
        {
            CharacterHealth characterHealth = other.gameObject.GetComponent<CharacterHealth>();
            characterHealth.TakeDamage(damage);
            
        }
        
    }
    
}
