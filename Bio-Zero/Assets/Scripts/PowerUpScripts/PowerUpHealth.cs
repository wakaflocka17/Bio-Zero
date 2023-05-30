using Player.Info;
using UnityEngine;
using UnityEngine.UI;

namespace PowerUpScripts
{
    public class PowerUpHealth : MonoBehaviour
    {
        private int maxLife = 100;

        [SerializeField] AudioClip powerUpSound;
        [HideInInspector] public AudioSource audioSource;
    
        public Slider healthSlider;

        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter(Collider other) {
            if(other.GetComponent<CharacterHealth>())
            {
                
                AudioManager.Instance.PlaySoundEffect(audioSource,powerUpSound);

                CharacterHealth player = other.GetComponent<CharacterHealth>();
                player.health = maxLife;
                healthSlider.value = player.health;
                this.gameObject.SetActive(false);
            }
        }
    }
}
