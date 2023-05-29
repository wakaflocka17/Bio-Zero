using Player.Info;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        EnemyZombiesSpawner spawner;
        [SerializeField] public List<GameObject> powerUps;
        private int killCounter;
        [SerializeField] public float health;
        Animator animator;
        [SerializeField] private Slider lifeBar;
        [SerializeField] private Transform powerUpPosition;
        public PlayerInfoManager ps;
        private GameObject currentPowerUp;

        [SerializeField] public CheatsManager cheatController;


        [SerializeField] private string enemyType;
        [SerializeField] private GameObject key;
        private int powerUpProbability = 25;
        private int keyProbability = 100;
        // Start is called before the first frame update

        private void Start()
        {
            spawner = GameObject.FindWithTag("Spawner").GetComponent<EnemyZombiesSpawner>();
            animator = GetComponent<Animator>();
            lifeBar.value = health;
            lifeBar.GameObject().SetActive(true);
        }

        public void TakeDamage(float damage)
        {

            if (!cheatController.cheatOSKToggle.isOn)
            {
                if (health > 0)
                {
                    health -= damage;
                    lifeBar.value -= damage;

                    if (health <= 0)
                        EnemyDeath();
                }

                else
                {
                    health -= health;
                    lifeBar.value -= lifeBar.value;
                }
            }

            else
            {
                health -= health;
                lifeBar.value -= health;
                EnemyDeath();
            }

        }

        // Update is called once per frame
        public void EnemyDeath()
        {
            spawner.enemyKilled();
            if (this.gameObject.GetComponent<barrackScript>())
            {
                powerUpProbability = 20;
            }

            int randInd = Random.Range(0, 100);
            //GameObject powerUp = Instantiate(fireBall, spherePos.position, spherePos.rotation);
            if (randInd < powerUpProbability)
            {
                int randomIndex = Random.Range(0, powerUps.Count);
                currentPowerUp = powerUps[randomIndex];
                Instantiate(currentPowerUp, powerUpPosition.position, powerUpPosition.rotation);
            }

            if (enemyType == "boss")
            {

                Instantiate(key, powerUpPosition.position, powerUpPosition.rotation);
            }

            killCounter++;
            DataManager.DataManager.instance.GetPlayer().numberKill += 1;
            lifeBar.GameObject().SetActive(false);
            ps.setKill(1);

        }

        public void Destroy()
        {
            Destroy(this.gameObject);
        }
    }
}
