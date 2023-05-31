using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

public class MiniBossScript : MonoBehaviour
{
    [SerializeField] private GameObject key;
    private float health;
    [SerializeField] private Transform keyPos;
    [SerializeField] private GameObject spawnPoint; 
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<EnemyHealth>().health;
    }

    // Update is called once per frame
    void Update()
    {
      if(health <= 0)
      {
        print("Sono dentro l'if");
        
      }
    }

    public void DestroyBoss()
    {
        
        Instantiate(key, keyPos.position, keyPos.rotation);
        Destroy(spawnPoint);
        Destroy(this.gameObject);
    }
}
