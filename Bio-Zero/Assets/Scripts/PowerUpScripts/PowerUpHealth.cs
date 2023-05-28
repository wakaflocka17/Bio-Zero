using Player.Info;
using UnityEngine;
using UnityEngine.UI;

namespace PowerUpScripts
{
    public class PowerUpHealth : MonoBehaviour
    {
        private int maxLife = 100;
    
        public Slider healthSlider;

        private void OnTriggerEnter(Collider other) {
            if(other.GetComponent<CharacterHealth>())
            {
                CharacterHealth player = other.GetComponent<CharacterHealth>();
                player.health = maxLife;
                healthSlider.value = player.health;
                this.gameObject.SetActive(false);
            }
        }
    }
}
