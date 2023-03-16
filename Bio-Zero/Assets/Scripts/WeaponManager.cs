using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] float fireRate;
    private float fireRateTimer;
    [SerializeField] bool semiAuto;
    // Start is called before the first frame update
    void Start()
    {
        fireRateTimer = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if(ShouldFire()) 
            Fire();
    }

    bool ShouldFire()
    {
        fireRateTimer += Time.deltaTime;

        if(fireRateTimer < fireRate) 
            return false;

        if(semiAuto && Input.GetKeyDown(KeyCode.Mouse0)) 
            return true;

        if(!semiAuto && Input.GetKey(KeyCode.Mouse0)) 
            return true;
        
        return false;
    }

    void Fire()
    {
        fireRateTimer = 0;
        Debug.Log("Fire");
    }
}

