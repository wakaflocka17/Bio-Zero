using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyZombiesSpawner : MonoBehaviour
{
    public GameObject[] myZombies; //Containes enemy zombies object
    public Transform[] spawnerZombies; //Transform path for Enemy

    private int randomIndexZombies; //used for choose more zombies
    private Vector3 randomIndexSpawner; //used for choose more Spawner

public Transform[] pathEnemy; //Transform path for Enemy
    private int pathEnemyIndex;
    private int index;
    private Vector3 actualCpTarget;

    private UnityEngine.AI.NavMeshAgent enemy; //Enemy object
    private Animator enemyState; //States Animation Enemy

    private float distanceEnemyPlayer;
    private bool flag;

    private float rangeAlert = 10.0f;
    private float rangeAttack = 01.0f;

    private float waitTime;
    private float initWaitTime = 1f; //Waiting time for spawn an Zombie object

    public GameObject playerTarget;
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
            randomIndexSpawner = spawnerZombies[Random.Range(0, myZombies.Length)].position;

            Instantiate(myZombies[randomIndexZombies], randomIndexSpawner, Quaternion.identity);

            waitTime = initWaitTime;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}