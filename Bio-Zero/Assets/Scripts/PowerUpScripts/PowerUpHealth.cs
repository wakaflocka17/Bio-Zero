using UnityEngine;
using UnityEngine.UI;

public class PowerUpHealth : MonoBehaviour
{
    private int maxLife = 100;
    
    public Slider healthSlider;
    
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
            player.health = maxLife;
            healthSlider.value = player.health;
            this.gameObject.SetActive(false);
        }
    }
}
