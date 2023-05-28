using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using WeaponScripts;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] public List<GameObject> activeSlot;
    [SerializeField] public List<GameObject> disableSlot;
    [SerializeField] public List<WeaponManager> weaponsElement;

    public void Start()
    {
        for (int i = 0; i < activeSlot.Count; i++)
        {
            activeSlot[i].SetActive(false);
            disableSlot[i].SetActive(false);

            if (i != 0)
            {
                Transform iconSlotActive = activeSlot[i].transform.Find("IconSlot");
                Transform iconSlotDisable = disableSlot[i].transform.Find("IconSlot");
                Image iconImageActive = iconSlotActive.GetComponent<Image>();
                Image iconImageDisable = iconSlotDisable.GetComponent<Image>();

                iconImageActive.sprite = null;
                iconImageActive.enabled = false;
                
                iconImageDisable.sprite = null;
                iconImageDisable.enabled = false;
            }
        }
        
        activeSlot[0].SetActive(true);
        disableSlot[1].SetActive(true);
        disableSlot[2].SetActive(true);
    }

    public void AddWeapon(WeaponManager weapon)
    {
        weaponsElement.Add(weapon);

        int weaponIndex = weaponsElement.Count - 1;

        AddForSingleSlot(activeSlot, weapon, weaponIndex);
        AddForSingleSlot(disableSlot, weapon, weaponIndex);
    }

    public void AddForSingleSlot(List<GameObject> listSlot, WeaponManager weapon, int weaponIndex)
    {
        Transform iconSlot = listSlot[weaponIndex].transform.Find("IconSlot");
        Image iconImage = iconSlot.GetComponent<Image>();
        SetActiveIcon(iconImage, weapon);
    }

    public void SetActiveIcon(Image imgSlot, WeaponManager weapon)
    {
        imgSlot.sprite = weapon.imageWeapon;
        imgSlot.enabled = true;
    }

    public void RemoveWeapon(WeaponManager weapon)
    {
        weaponsElement.Remove(weapon);
        
        int weaponIndex = weaponsElement.Count - 1;

        RemoveForSingleSlot(activeSlot, weaponIndex);
        RemoveForSingleSlot(disableSlot, weaponIndex);
    }

    public void RemoveForSingleSlot(List<GameObject> listSlot, int weaponIndex)
    {
        Transform iconSlot = listSlot[weaponIndex].transform.Find("IconSlot");
        Transform iconNextSlot = listSlot[weaponIndex + 1].transform.Find("IconSlot");
        
        Image iconImage = iconSlot.GetComponent<Image>();
        Image iconNextImage = iconNextSlot.GetComponent<Image>();
        
        if (weaponIndex < listSlot.Count - 1)
        {
            SetDisableIcon(iconImage, iconNextImage);
        }

        else
        {
            SetDisableIcon(iconImage);
        }
        
    }
    
    public void SetDisableIcon(Image imgSlot, Image imgNextSlot)
    {
        imgSlot.sprite = imgNextSlot.sprite;
        imgNextSlot.sprite = null;
        imgNextSlot.enabled = false;
    }
    
    public void SetDisableIcon(Image imgSlot)
    {
        imgSlot.sprite = null;
        imgSlot.enabled = false;
    }

    public void SwitchWeapon(int index)
    {
        if (index != 0)
        {
            index -= 1;
        }
        
        //Because Weapon Index start from one to three
        
        if (index >= 0 && index < activeSlot.Count)
        {
            //Active Slot
            activeSlot[index].SetActive(true);
            disableSlot[index].SetActive(false);

            // Disable each other
            for (int i = 0; i < activeSlot.Count; i++)
            {
                if (i != index)
                {
                    activeSlot[i].SetActive(false);
                    disableSlot[i].SetActive(true);
                }
            }
            
        }
        else
        {
            Debug.LogError("Invalid weapon index");
        }
    }

}