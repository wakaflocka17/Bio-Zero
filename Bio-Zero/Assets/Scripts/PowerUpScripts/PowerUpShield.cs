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
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<CharacterHealth>())
            {
                print("1");
                CharacterHealth player = other.GetComponent<CharacterHealth>();
                if (player.shield <= 100)
                {
                    player.shield += shield;
                    shieldSlider.value = player.shield;
                }
                Destroy(this.gameObject);
            }
        }
    }
}
