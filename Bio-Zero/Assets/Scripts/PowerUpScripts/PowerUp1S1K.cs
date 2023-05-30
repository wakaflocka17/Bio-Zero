using System.Collections;
using UnityEngine;
using WeaponScripts;

namespace PowerUpScripts
{
    public class PowerUp1S1K : MonoBehaviour
    {
        private int extraDamage = 300;
         [SerializeField] AudioClip powerUpSound;
        [HideInInspector] public AudioSource audioSource;
    
        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();

        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnTriggerEnter(Collider other) {
            if(other.GetComponent<WeaponManager>())
            {
                AudioManager.Instance.PlaySoundEffect(audioSource,powerUpSound);

                WeaponManager weapon = other.GetComponent<WeaponManager>();
                weapon.damage = extraDamage;
                Debug.Log("primaDiCoroutine");
                StartCoroutine(DefaultDamage(weapon));
                this.transform.GetChild(0).gameObject.SetActive(false);
            
            }
        }

        private IEnumerator DefaultDamage(WeaponManager weapon)
        {
            Debug.Log("ritardo");
            yield return new WaitForSeconds(8.0f);
            weapon.damage = 20;
        }
    }
}
