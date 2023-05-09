using UnityEngine;

[System.Serializable]
public class InfoGameData
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
    public InfoGameData(string nickname)
    {
        this.nickname = nickname;
        numberLevel = 1;
        numberKill = 0;
        ammoPlayer.ammoInventory = 180;
        ammoPlayer.currentAmmo = 30;
        
        coordPlayer = Vector3.zero;
        
        timePlayer.hours = 0;
        timePlayer.minutes = 0;
        timePlayer.seconds = 0;
    }
    
}
