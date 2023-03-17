using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAmmo : MonoBehaviour
{
    public int clipSize;
    public int extraAmmo;
    public int currentAmmo;

    [SerializeField] AudioClip magOutSound;
    AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentAmmo = clipSize;
    }

    public void Reload()
    {
        
        if(extraAmmo >= clipSize)
        {
            audioSource.PlayOneShot(magOutSound);
            int ammoToReload = clipSize - currentAmmo;
            extraAmmo -= ammoToReload;
            currentAmmo += ammoToReload;
        }
        else if(extraAmmo > 0)
        {
            audioSource.PlayOneShot(magOutSound);
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
    }
}
