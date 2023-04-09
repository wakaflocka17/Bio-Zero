using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpRotation : MonoBehaviour
{
   
    [SerializeField] private Vector3 rotation;
    ParticleSystem pS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }
}

