using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponAmmo : MonoBehaviour
{
    public int clipSize; //Dim for Clip Gunshot
    public int extraAmmo; //Ammo in Inventory
    public int currentAmmo;

    public TextMeshProUGUI textAmmoInventory; //Extra ammo in Ammo Inventory
    public TextMeshProUGUI textCurrentAmmo; //Ammo in Clip GunShot
    
    public AudioClip magOutSound;
    public AudioClip magInSound;
    public AudioClip slideBackSound;

    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = clipSize;
        
        //I've set Ammo HUD
        textCurrentAmmo.text = currentAmmo.ToString();
        textAmmoInventory.text = extraAmmo.ToString();
    }

    public void Reload()
    {

        if(extraAmmo >= clipSize)
        {

            int ammoToReload = clipSize - currentAmmo;
            extraAmmo -= ammoToReload;
            currentAmmo += ammoToReload;
            
        }
        else if(extraAmmo > 0)
        {

            if(extraAmmo + currentAmmo > clipSize)
            {
                int leftOverAmmo = extraAmmo + currentAmmo - clipSize;
                extraAmmo = leftOverAmmo;
                currentAmmo = clipSize;
            }
            else
            {
                currentAmmo += extraAmmo;
                extraAmmo = 0;
            }
        }
        
        textCurrentAmmo.text = currentAmmo.ToString();
        textAmmoInventory.text = extraAmmo.ToString();
    }

    public void AddAmmo(int extraAmmo)
    {
        this.extraAmmo += extraAmmo;
        textAmmoInventory.text = extraAmmo.ToString();
    }
}