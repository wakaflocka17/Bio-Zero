using UnityEngine;
using UnityEngine.SceneManagement;

namespace Enemy
{
    public class EnemyZombiesSpawner : MonoBehaviour
    {
        private int randomIndexZombies; //used for choose more zombies
        private Vector3 randomIndexSpawner; //used for choose more Spawner

        private float waitTime;
        private float initWaitTime = 1f; //Waiting time for spawn an Zombie object
    
        public GameObject[] myZombies; //Containes enemy zombies object
        public Transform[] spawnerZombies; //Transform path for Enemy
        static private int nZombies;
        private int maxZombies = 50;
        Scene currentScene;
    
        // Start is called before the first frame update
        void Start()
        {
            currentScene = SceneManager.GetActiveScene();
            nZombies = 0;
            randomIndexZombies = 0;
            randomIndexSpawner = new Vector3();
            waitTime = initWaitTime;
        }

        // Update is called once per frame
        void Update()
        {
            if(currentScene.name == "Town")
            {
                maxZombies = 25;
            } else if(currentScene.name == "Nature")
            {
                maxZombies = 400;
            } else if(currentScene.name == "Desert")
            {
                maxZombies = 600;
            }

            if(nZombies >= maxZombies)
            {
                return;
            }
            if (waitTime <= 0)
            {
                randomIndexZombies = Random.Range(0, myZombies.Length);
                randomIndexSpawner = spawnerZombies[Random.Range(0, spawnerZombies.Length)].position;
                if(nZombies <= 50)
                {
                //Spawn random zombie in random position
                    Instantiate(myZombies[randomIndexZombies], randomIndexSpawner, Quaternion.identity);
                    nZombies++;
                }

                waitTime = initWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        public int GetNZombies()
        {
            return nZombies;
        }

        public int enemyKilled()
        {
            return nZombies--;
        }
    }
}