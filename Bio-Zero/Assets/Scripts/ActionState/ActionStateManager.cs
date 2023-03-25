using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ActionStateManager : MonoBehaviour
{
    [HideInInspector] public ActionBaseState currentState;
    public ReloadState Reload = new ReloadState();
    public DefaultState Default = new DefaultState();
    

    public GameObject currentWeapon;
    [HideInInspector] public WeaponAmmo ammo;
    AudioSource audioSource;

    [HideInInspector] public Animator animator;

    public MultiAimConstraint rHandAim;
    public TwoBoneIKConstraint lHandIK;

    // Start is called before the first frame update
    void Start()
    {
        SwitchState(Default);
        ammo = currentWeapon.GetComponent<WeaponAmmo>();
        audioSource = currentWeapon.GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
=======
        ammo = currentWeapon.ammo;
        audioSource = currentWeapon.audioSource;

        if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3)) 
        {
            WeaponSwitched();
            rHandAim.weight = 0;
            lHandIK.weight = 0;
        }

>>>>>>> Stashed changes
        currentState.UpdateState(this);
    }

    public void SwitchState(ActionBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
    
<<<<<<< Updated upstream
=======
    //called at the end of reload animation
>>>>>>> Stashed changes
    public void WeaponReloaded()
    {
        ammo.Reload();
        SwitchState(Default);
    }

<<<<<<< Updated upstream
=======

    public void WeaponSwitched()
    {
        rHandAim.weight = 0;
        lHandIK.weight = 0;
        SwitchWeapon();
        SwitchState(Default);
    }

    //sounds called in the reload animation
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======

    //function to activate the weapon chosen by the player and deactivate all the others 
   public void SwitchWeapon()
    {
        int weaponIndex = 0;

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

    //called in the switchWeapon animation as an event to stop shooting while we are switching the weapon
    public void stopFire()
    {
        currentWeapon.isSwitching = true;
    }

    //called in the switchWeapon animation as an event to start shooting again after we switched weapon
    public void startFire()
    {
        currentWeapon.isSwitching = false;
    }
>>>>>>> Stashed changes
}
