using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using WeaponScripts;

namespace Player.ActionState
{
    public class ActionStateManager : MonoBehaviour
    {
        [HideInInspector] public ActionBaseState currentState;
        public ReloadState Reload = new ReloadState();
        public DefaultState Default = new DefaultState();
       

        [SerializeField] public List<WeaponManager> weapons;
        [HideInInspector] public WeaponManager currentWeapon;
        [HideInInspector] public WeaponAmmo ammo;
        AudioSource audioSource;

        [HideInInspector] public Animator animator;

        public MultiAimConstraint rHandAim;
        public TwoBoneIKConstraint lHandIK;

        [HideInInspector] public int weaponIndex = 0;
        public int componentIndex = 0;

        // Start is called before the first frame update
        void Start()
        {
            SwitchState(Default);
            currentWeapon = weapons[0];
            currentWeapon.equipped = true;
            currentWeapon.isArmed = true;
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
            if(weapons.Count == 0)
            {
                rHandAim.weight = 0;
                lHandIK.weight = 0;
                animator.SetBool("isArmed", false);
               
            }
            else
            {
                animator.SetBool("isArmed", true);
                
            }
           
            DropWeapon();
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
        
            // bool is_a_number = Int32.TryParse(Input.inputString, out weaponIndex);

            if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2)
                                                || Input.GetKeyDown(KeyCode.Alpha3)) {
                weaponIndex = int.Parse(Input.inputString);
            }

            if (weaponIndex >= 1 && weaponIndex <= weapons.Count && weapons[weaponIndex - 1] != currentWeapon)
            {
                animator.SetTrigger("Switch");
                currentWeapon = weapons[weaponIndex - 1];
                currentWeapon.isArmed = true;
                weapons[weaponIndex - 1].gameObject.SetActive(true);

                foreach(WeaponManager weapon in weapons)
                {
                    if(weapon != currentWeapon)
                    { 
                        weapon.gameObject.SetActive(false);
                        weapon.isArmed = false;
                    }
                
                }
            } 

            print(weaponIndex);
        } 
/*
    public void AssignWeapon(WeaponManager weapon) {
        if(weapons.Length < 3)
        {
            weapon.GetComponent<WeaponMovement>().enabled = false;
            //oggetto 1 figlio di oggetto 2
            weapon.transform.parent = weapons[0].transform.parent; 
            
            Array.Resize(ref weapons, weapons.Length + 1);
            weapons[weapons.Length - 1] = weapon; 

            weapon.transform.localPosition = weapons[0].transform.localPosition;
            weapon.transform.localRotation = weapons[0].transform.localRotation;
        }
    }*/

        public void DropWeapon()
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("lancia");
                weapons.Remove(currentWeapon);
                currentWeapon.Drop();
                currentWeapon = weapons[0];
                currentWeapon.gameObject.SetActive(true);
            }
        }
    }
}
