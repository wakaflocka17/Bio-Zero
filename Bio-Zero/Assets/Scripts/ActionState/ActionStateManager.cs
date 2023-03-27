using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using System;

public class ActionStateManager : MonoBehaviour
{
    [HideInInspector] public ActionBaseState currentState;
    public ReloadState Reload = new ReloadState();
    public DefaultState Default = new DefaultState();
    public SwitchWeaponState ChangeWeapon = new SwitchWeaponState();
    

    [SerializeField] WeaponManager[] weapons;
    WeaponManager currentWeapon;
    [HideInInspector] public WeaponAmmo ammo;
    AudioSource audioSource;

    [HideInInspector] public Animator animator;

    public MultiAimConstraint rHandAim;
    public TwoBoneIKConstraint lHandIK;

    // Start is called before the first frame update
    void Start()
    {
        SwitchState(Default);
        currentWeapon = weapons[0];
        ammo = currentWeapon.ammo;
        audioSource = currentWeapon.GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ammo = currentWeapon.ammo;
        audioSource = currentWeapon.audioSource;

        if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2)
        || Input.GetKeyDown(KeyCode.Alpha3)) {
            WeaponSwitched();
        }

        currentState.UpdateState(this);
    }

    public void SwitchState(ActionBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
    

    public void WeaponReloaded()
    {
        ammo.Reload();
        SwitchState(Default);
    }

    public void WeaponSwitched()
    {
        SwitchWeapon();
        SwitchState(Default);
    }

    public void MagOut()
   {
        audioSource.PlayOneShot(ammo.magOutSound);
   }

   public void MagIn()
   {
        audioSource.PlayOneShot(ammo.magInSound);
   }

   public void SlideBack()
   {
        audioSource.PlayOneShot(ammo.slideBackSound);
   }

   public void SwitchWeapon()
    {
        int weaponIndex = 0;
        // bool is_a_number = Int32.TryParse(Input.inputString, out weaponIndex);

        if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2)
        || Input.GetKeyDown(KeyCode.Alpha3)) {
            weaponIndex = int.Parse(Input.inputString);
        }

        if (weaponIndex >= 1 && weaponIndex < weapons.Length + 1 && weapons[weaponIndex-1] != currentWeapon)
        {
            animator.SetTrigger("Switch");
            currentWeapon = weapons[weaponIndex - 1];
            weapons[weaponIndex - 1].gameObject.SetActive(true);

            foreach(WeaponManager weapon in weapons)
            {
                if(weapon != weapons[weaponIndex - 1])
                    weapon.gameObject.SetActive(false);
            }
        } 

        print(weaponIndex);
    } 
}
