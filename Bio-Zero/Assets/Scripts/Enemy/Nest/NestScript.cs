using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

public class NestScript : MonoBehaviour
{
    float nestHealth;
    [SerializeField] private GameObject smoke;
    [SerializeField] private GameObject electricity;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nestHealth = GetComponent<EnemyHealth>().health;

        if(nestHealth <= 0)
        {
            electricity.SetActive(false);
            smoke.SetActive(true);
            this.gameObject.SetActive(false);
        }
        
    }
}
