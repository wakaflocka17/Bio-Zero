using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Player.Info;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        public Transform[] pathEnemy; //Transform path for Enemy
        private int pathEnemyIndex;
        private int index;
        private Vector3 actualCpTarget;

        private NavMeshAgent enemy; //Enemy object
        private Animator enemyState; //States Animation Enemy

        private float distanceEnemyPlayer;

        [SerializeField] private float rangeAlert;
        [SerializeField] private float rangeAttack;
    
        private float waitTime;
        private float initWaitTime = 1f;

        public GameObject playerTarget;
        private float damageAttack;
        private EnemyHealth health;
        private Vector3 playerPos;
        [SerializeField] ParticleSystem bloodSplatter;
        [SerializeField] List<Collider> handColliders;


        // Start is called before the first frame update
        void Start()
        {
            health = GetComponent<EnemyHealth>();								
            enemy = GetComponent<NavMeshAgent>();
            enemyState = GetComponent<Animator>();
            waitTime = initWaitTime;
            pathEnemyIndex = Random.Range(0, pathEnemy.Length);
        }

        // Update is called once per frame
        void Update()
        {
            ResetAnimatorState(enemyState);

            if(playerTarget.GetComponent<CharacterHealth>().health > 0) 
            {
                playerPos = playerTarget.transform.position;
            }

            if (health.health > 0)
            {
                float distance = Vector3.Distance(playerPos, transform.position);
    
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
            // enemy.isStopped = false;
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
            distanceEnemyPlayer = Vector3.Distance(transform.position, playerPos);
        
            if (distanceEnemyPlayer < rangeAttack)
            { //Distance between Enemy and Player is lower than 1
                enemy.velocity = Vector3.zero;
                enemy.isStopped = true;
                enemyState.SetBool("isAlert", false);
                AttackState();
            }
        
            else if (distanceEnemyPlayer < rangeAlert)
            { //Distance between Enemy and Player is lower than 10
                enemy.isStopped = false;
                enemy.destination = playerPos;
                enemyState.SetBool("isAlert", true);
                //enemy.SetDestination(playerTarget.transform.position);
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
            enemy.SetDestination(playerPos);
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

        //void rotateToPlayer
    }
}
