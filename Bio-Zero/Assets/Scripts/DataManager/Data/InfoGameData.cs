using UnityEngine;

[System.Serializable]
public class InfoGameData : MonoBehaviour
{
    public struct TimePlayer
    {
        public int hours;
        public int minutes;
        public int seconds;
    }

    public struct WeaponAmmo
    {
        public int currentAmmo;
        public int ammoInventory;
    }
    
    public string nickname;
    public int numberKill;
    public int numberLevel;
    public WeaponAmmo ammoPlayer;
    public Vector3 coordPlayer;
    public TimePlayer timePlayer;
    public CharacterHealth statsLifePlayer;
    
    //The default (and empty) constructor
    //will be used when there is no data to load
    public InfoGameData()
    {
        this.name = "";
        this.numberLevel = 1;
        this.numberKill = 0;
        this.ammoPlayer.ammoInventory = 180;
        this.ammoPlayer.currentAmmo = 30;
        
        this.coordPlayer = Vector3.zero;
        
        this.timePlayer.hours = 0;
        this.timePlayer.minutes = 0;
        this.timePlayer.seconds = 0;

        this.statsLifePlayer.health = 100;
        this.statsLifePlayer.shield = 0;
    }
    
}
