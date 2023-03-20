using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Header("Fire Rate")]
    [SerializeField] float fireRate;
    private float fireRateTimer;
    [SerializeField] bool semiAuto;

    [Header("Bullet Properties")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform barrelPos;
    [SerializeField] float bulletVelocity;
    [SerializeField] int bulletsPerShot;
    public float damage = 20;
    AimStateManager aim;

    [SerializeField] AudioClip gunShot;
    AudioSource audioSource;
    WeaponAmmo ammo;

    ActionStateManager actions;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        aim = GetComponentInParent<AimStateManager>();
        ammo = GetComponent<WeaponAmmo>();
        actions = GetComponentInParent<ActionStateManager>();
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

        if(ammo.currentAmmo == 0) 
            return false;

        if(fireRateTimer < fireRate) 
            return false;
        if(actions.currentState == actions.Reload) return false;

        if(semiAuto && Input.GetKeyDown(KeyCode.Mouse0)) 
            return true;

        if(!semiAuto && Input.GetKey(KeyCode.Mouse0)) 
            return true;
        
        return false;
    }

    void Fire()
    {
        fireRateTimer = 0;
        ammo.currentAmmo--;

        barrelPos.LookAt(aim.aimPos);
        audioSource.PlayOneShot(gunShot);
        
        for(int i = 0; i < bulletsPerShot; i++)
        {
            GameObject currentBullet = Instantiate(bullet, barrelPos.position, barrelPos.rotation);

            Bullet bulletScript = currentBullet.GetComponent<Bullet>();
            bulletScript.weapon = this;
            Rigidbody rb = currentBullet.GetComponent<Rigidbody>();
            rb.AddForce(barrelPos.forward * bulletVelocity, ForceMode.Impulse);
        }
    }
}

