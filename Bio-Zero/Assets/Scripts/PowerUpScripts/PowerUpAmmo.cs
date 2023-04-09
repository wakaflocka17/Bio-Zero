using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpAmmo : MonoBehaviour
{
     private int extraAmmo = 180;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<WeaponAmmo>())
        {
            WeaponAmmo ammo = other.GetComponent<WeaponAmmo>();
            ammo.AddAmmo(extraAmmo);
            this.gameObject.SetActive(false);
        }
    }
}
