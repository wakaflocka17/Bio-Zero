using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatsManager : MonoBehaviour
{
    [Header("Cheats Management")]
    [SerializeField] private Toggle toggleOSK;
    [SerializeField] private Toggle toggleInfiniteAmmo;
    [SerializeField] private Toggle toggleNoDamage;
    
    // Start is called before the first frame update
    void Start()
    {
        toggleOSK.isOn = false;
        toggleInfiniteAmmo.isOn = false;
        toggleNoDamage.isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (toggleOSK.isOn)
        {
            modeOSK();
        }

        if (toggleNoDamage.isOn)
        {
            modeNoDamage();
        }

        if (toggleInfiniteAmmo.isOn)
        {
            modeInfiniteAmmo();
        } 
    }

    public void modeOSK()
    {
        
    }
    
    public void modeNoDamage()
    {
        
    }
    
    public void modeInfiniteAmmo()
    {
        
    }
}
