using Player.Info;
using UnityEngine;
using UnityEngine.UI;

namespace PowerUpScripts
{
    public class PowerUpShield : MonoBehaviour
    {
        private float shield = 25;

        public Slider shieldSlider;
    
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnTriggerEnter(Collider other) {
            if(other.GetComponent<CharacterHealth>())
            {
                CharacterHealth player = other.GetComponent<CharacterHealth>();
                if(player.shield <= 100)
                {
                    player.shield += shield;
                    shieldSlider.value = player.shield;
                }
                this.gameObject.SetActive(false);
            }
        }
    }
}
