using System.Collections;
using UnityEngine;
using WeaponScripts;

namespace PowerUpScripts
{
    public class PowerUp1S1K : MonoBehaviour
    {
        private int extraDamage = 300;
    
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnTriggerEnter(Collider other) {
            if(other.GetComponent<WeaponManager>())
            {
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
