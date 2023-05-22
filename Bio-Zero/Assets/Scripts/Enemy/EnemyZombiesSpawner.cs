using UnityEngine;

namespace Enemy
{
    public class EnemyZombiesSpawner : MonoBehaviour
    {
        private int randomIndexZombies; //used for choose more zombies
        private Vector3 randomIndexSpawner; //used for choose more Spawner

        private float waitTime;
        private float initWaitTime = 5f; //Waiting time for spawn an Zombie object
    
        public GameObject[] myZombies; //Containes enemy zombies object
        public Transform[] spawnerZombies; //Transform path for Enemy
    
        // Start is called before the first frame update
        void Start()
        {
            randomIndexZombies = 0;
            randomIndexSpawner = new Vector3();
            waitTime = initWaitTime;
        }

        // Update is called once per frame
        void Update()
        {
            if (waitTime <= 0)
            {
                randomIndexZombies = Random.Range(0, myZombies.Length);
                randomIndexSpawner = spawnerZombies[Random.Range(0, spawnerZombies.Length)].position;

                //Spawn random zombie in random position
                Instantiate(myZombies[randomIndexZombies], randomIndexSpawner, Quaternion.identity);

                waitTime = initWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}