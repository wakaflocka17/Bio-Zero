using DataManager;
using DataManager.Data;
using TMPro;
using UnityEngine;

namespace WeaponScripts
{
    public class WeaponAmmo : MonoBehaviour, InterfaceDataManager
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

        public void AddAmmo(int extra)
        {
            this.extraAmmo += extraAmmo;
            textAmmoInventory.text = this.extraAmmo.ToString();
        }

        public void LoadData(InfoGameData infoPlayer)
        {
            currentAmmo = infoPlayer.currentammo;
            extraAmmo = infoPlayer.ammoInventory;
        }

        public void SaveData(ref InfoGameData infoPlayer)
        {
            infoPlayer.currentammo = int.Parse(textCurrentAmmo.text);
            infoPlayer.ammoInventory = int.Parse(textAmmoInventory.text);
        }
    }
}