using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Weapons : MonoBehaviour
{
    [SerializeField] public WeaponManager[] weapons;
    [HideInInspector] public WeaponManager currentWeapon;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
       currentWeapon = weapons[1]; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchWeapon()
    {
        int weaponIndex;
        bool is_a_number = Int32.TryParse(Input.inputString, out weaponIndex);
        Debug.Log(weaponIndex);
        
        if (is_a_number && weaponIndex >= 1 && weaponIndex < weapons.Length + 1)
        {
            currentWeapon = weapons[weaponIndex - 1];
            weapons[weaponIndex - 1].gameObject.SetActive(true);

            foreach(WeaponManager weapon in weapons)
            {
                if(weapon != weapons[weaponIndex - 1])
                    weapon.gameObject.SetActive(false);
            }
        }       
    } 
}
