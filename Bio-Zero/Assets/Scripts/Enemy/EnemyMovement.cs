using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{
    public Transform[] pathEnemy; //Transform path for Enemy
    private int pathEnemyIndex;
    private int index;
    private Vector3 actualCpTarget;

    private NavMeshAgent enemy; //Enemy object
    private Animator enemyState; //States Animation Enemy

    private float distanceEnemyPlayer;

    private float rangeAlert = 10.0f;
    private float rangeAttack = 01.0f;
    
    private float waitTime;
    private float initWaitTime = 1f;

    public GameObject playerTarget;
    [SerializeField] private float gravity = -9.81f;
    private float damageAttack;
	private EnemyHealth health;
    
    [SerializeField] ParticleSystem bloodSplatter;
    [SerializeField] List<Collider> handColliders;
    [SerializeField] CharacterHealth playerHealth;


    // Start is called before the first frame update
    void Start()
    {
	    health = GetComponent<EnemyHealth>();								
        enemy = GetComponent<NavMeshAgent>();
        playerTarget = GameObject.FindWithTag("Player");
        enemyState = GetComponent<Animator>();
        waitTime = initWaitTime;
        pathEnemyIndex = Random.Range(0, pathEnemy.Length);
    }
    // Update is called once per frame
    void Update()
    {
        ResetAnimatorState(enemyState);

        if (health.health > 0)
        {
            float distance = Vector3.Distance(playerTarget.transform.position, transform.position);
        
            if (distance > rangeAlert)
            {
                idleStateMode();
            }
            
            else
            {
                followPlayer();
            }
        }

        else
        {
            enemyState.SetBool("isDead", true);
        }
        
    }
    private void idleStateMode()
    {
        enemy.SetDestination(pathEnemy[pathEnemyIndex].position);
        
        if (Vector3.Distance(transform.position, pathEnemy[pathEnemyIndex].position) < 3.0f)
        {
            if (waitTime <= 0)
            {
                pathEnemyIndex = Random.Range(0, pathEnemy.Length);
                waitTime = initWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    
    private void followPlayer()
    {
        //Set distance offset between enemy ai and player
        distanceEnemyPlayer = Vector3.Distance(transform.position, playerTarget.transform.position);
        
        if (distanceEnemyPlayer < rangeAttack)
        { //Distance between Enemy and Player is lower than 1
            enemyState.SetBool("isAttack", true);
        }
        
        else if (distanceEnemyPlayer < rangeAlert)
        { //Distance between Enemy and Player is lower than 10
            enemyState.SetBool("isAlert", true);
            enemy.SetDestination(playerTarget.transform.position);
        }
    }
    public void ResetAnimatorState(Animator animator)
    {
        animator.SetBool("isAlert", false);
        animator.SetBool("isAttack", false);
    }
    
    void AttackState()
    {
        enemyState.SetBool("isAttack", true);
    }
    
    void AllertState()
    {
        enemyState.SetBool("isAlert", true);
        enemy.SetDestination(playerTarget.transform.position);
    }
    
    void EnableCollider()
    {
        foreach(Collider coll in handColliders)
        {
            coll.isTrigger = true;
        }
    }
    
    void DisableCollider()
    {
        foreach(Collider coll in handColliders)
        {
            coll.isTrigger = false;
        }
    }

    void ShowBlood()
    {
        bloodSplatter.Play();
    }
    
    void StopBlood()
    {
        bloodSplatter.Stop();
    }
}
