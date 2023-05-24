using System.Collections;
using System.Collections.Generic;
using Enemy;
using Player.Info;
using UnityEngine;
using UnityEngine.UI;

public class CheatsManager : MonoBehaviour
{
    public Toggle cheatOSKToggle;
    public Toggle cheatNoDamageToggle;
    public Toggle cheatInfiniteAmmo;

    [SerializeField] public PlayerInfoManager player;

    [SerializeField] private GameObject infinityAmmo;
    [SerializeField] private GameObject normalAmmo;
    

    private void Start()
    {
        // Listener check the state when isOn change
        cheatOSKToggle.onValueChanged.AddListener(OnCheatOSKToggleValueChanged);
        cheatNoDamageToggle.onValueChanged.AddListener(OnCheatNoDamageToggleValueChanged);
        cheatInfiniteAmmo.onValueChanged.AddListener(OnCheatInfiniteAmmoToggleValueChanged);
    }

    private void OnCheatOSKToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            // Codice da eseguire quando il cheat 1 viene attivato
            Debug.Log("Cheat OSK attivato");
        }
        else
        {
            // Codice da eseguire quando il cheat 1 viene disattivato
            Debug.Log("Cheat OSK disattivato");
        }
    }

    private void OnCheatNoDamageToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            // Codice da eseguire quando il cheat 2 viene attivato
            Debug.Log("Cheat NoDamage attivato");
        }
        else
        {
            // Codice da eseguire quando il cheat 2 viene disattivato
            Debug.Log("Cheat NoDamage disattivato");
        }
    }

    private void OnCheatInfiniteAmmoToggleValueChanged(bool isOn)
    {
        if (isOn)
        {
            // Codice da eseguire quando il cheat 3 viene attivato
            Debug.Log("Cheat InfiniteAmmo attivato");
            normalAmmo.SetActive(false);
            infinityAmmo.SetActive(true);
        }
        else
        {
            // Codice da eseguire quando il cheat 3 viene disattivato
            Debug.Log("Cheat InfiniteAmmo disattivato");
            infinityAmmo.SetActive(false);
            normalAmmo.SetActive(true);
        }
    }
    
}