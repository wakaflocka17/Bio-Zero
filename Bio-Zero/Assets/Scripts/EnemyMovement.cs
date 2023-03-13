using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent enemy;

    private Animator enemyState;

    private float distanceEnemyPlayer;
    
    private float rangeAlert = 15.0f;
    private float rangeAttack = 03.0f;

    public GameObject playerTarget;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        playerTarget = GameObject.FindWithTag("Player");
        enemyState = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        ResetAnimatorState(enemyState);
        enemy.isStopped = false;
        
        //Set distance offset between enemy ai and player
        distanceEnemyPlayer = Vector3.Distance(enemy.transform.position, playerTarget.transform.position);
        
        if (distanceEnemyPlayer < rangeAttack)
        { //Distance between Enemy and Player is lower than 1
            enemyState.SetBool("isAttack", true);
            enemy.SetDestination(playerTarget.transform.position);
        }
        
        else if (distanceEnemyPlayer < rangeAlert)
        { //Distance between Enemy and Player is lower than 10
            enemyState.SetBool("isAlert", true);
            enemy.SetDestination(playerTarget.transform.position);
        }

        else
        { //Distance between Enemy and Player is lower than 1
            enemyState.SetBool("isWalking", true);
            enemy.isStopped = false;
        }
        
    }

    public void ResetAnimatorState(Animator animator)
    {
        animator.SetBool("isIdle", false);
        animator.SetBool("isAlert", false);
        animator.SetBool("isAttack", false);
    }
}
