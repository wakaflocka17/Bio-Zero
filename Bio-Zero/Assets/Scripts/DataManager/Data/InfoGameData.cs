using UnityEngine;

namespace DataManager.Data
{
    [System.Serializable]
    public class InfoGameData
    {
        public string nickname;
        public int numberKill;
        public int numberLevel;
        public int currentammo;
        public int ammoInventory;
        public Vector3 coordPlayer;
        public int hours;
        public int seconds;
        public int minutes;
        public float healthPlayer;
        public float shieldPlayer;
    
        //The default (and empty) constructor
        //will be used when there is no data to load
        public InfoGameData(string nickname)
        {
            this.nickname = nickname;
            numberLevel = 1;
            numberKill = 0;
            ammoInventory = 120;
            currentammo = 30;
        
            coordPlayer = Vector3.zero;
        
            hours = 0;
            minutes = 0;
            seconds = 0;

            healthPlayer = 100.0f;
            shieldPlayer = 0.0f;
        }
        
    }
}
