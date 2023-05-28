using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

public class barrackScript : MonoBehaviour
{
    
    private float health;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject checkPoint;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        health = this.gameObject.GetComponent<EnemyHealth>().health;

        if(health <= 0)
        {
            Destroy(checkPoint);
            Instantiate(explosion, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
