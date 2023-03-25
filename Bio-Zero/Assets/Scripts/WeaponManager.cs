using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

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
    
    [Header("Audio Properties")]
    [SerializeField] AudioClip gunShot;
    [HideInInspector] public AudioSource audioSource;
    [HideInInspector] public WeaponAmmo ammo;

    [Header("Camera Properties")]
    [SerializeField] CinemachineVirtualCamera vCam;
    [HideInInspector] public float hipFov;
    [HideInInspector] public float currentFov;
    public float fovSmoothSpeed = 1f;

    [Header("Weapon effects")]
    Light muzzleFlashlight;
    ParticleSystem gunShotParticles;
    float lightIntensity;
    [SerializeField] float lightReturnSpeed = 20;

    [HideInInspector] public WeaponAmmo ammo;
    ActionStateManager actions;
    CharacterHealth playerHealth;
    AimStateManager aim;

    [HideInInspector] public bool isSwitching = false;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponentInParent<CharacterHealth>();
        hipFov = vCam.m_Lens.FieldOfView;
        audioSource = GetComponent<AudioSource>();
        aim = GetComponentInParent<AimStateManager>();
        ammo = GetComponent<WeaponAmmo>();
        actions = GetComponentInParent<ActionStateManager>();
        muzzleFlashlight = GetComponentInChildren<Light>();
        lightIntensity = muzzleFlashlight.intensity;
        muzzleFlashlight.intensity = 0;
        gunShotParticles = GetComponentInChildren<ParticleSystem>();
        fireRateTimer = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if(ShouldFire()) 
        {
            vCam.m_Lens.FieldOfView = Mathf.Lerp(vCam.m_Lens.FieldOfView, currentFov, fovSmoothSpeed * Time.deltaTime);
            Fire();
        }
        muzzleFlashlight.intensity = Mathf.Lerp(muzzleFlashlight.intensity, 0, lightReturnSpeed * Time.deltaTime);
    }

    bool ShouldFire()
    {
        fireRateTimer += Time.deltaTime;

        if(isSwitching)
            return false;
            
        if(ammo.currentAmmo == 0) 
            return false;
            
        if(playerHealth.health <= 0)
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
        TriggerMuzzleFlash();
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

    void TriggerMuzzleFlash()
    {
        gunShotParticles.Play();
        muzzleFlashlight.intensity = lightIntensity;
    }


}

