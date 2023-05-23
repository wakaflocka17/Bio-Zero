using Player.Info;
using UnityEngine;
using UnityEngine.AI;
using Boss.FireBallScript;

namespace Boss
{
    public class BossAIMovement : MonoBehaviour
    {
        private NavMeshAgent boss; //Enemy object
        private Animator bossState; //States Animation Enemy
    
        public Transform[] pathBoss; //Transform path for Boss
        private int pathBossIndex;
        private int index;

        private float fireRateTime;
        private float initFireRateTime = 5.0f;
    
        private float waitTime;
        private float initWaitTime = 05.0f;
    
        //Variable for first phase Boss
        private float rangeAlert = 0.0f; //Range for set true the Alert flag for first stage
        private float rangeAttack = 0.0f; //Range for set true the Attack flag

        private float fireBallTime;
        private float initFireBallTime = 03.0f;

        [SerializeField] private GameObject stick;
        [SerializeField] private Transform spherePos;
        [SerializeField] private GameObject fireBall;
        [SerializeField] float fireBallVelocity = 5;

    
        //Variable for second phase Boss
    
        // Create a timer for shooting fireball

        private BossHealth bossHealth;
        [SerializeField] ParticleSystem bloodSplatter; //Blood for Boss damages
        [SerializeField] ParticleSystem attackEffect; //Effect for Boss Attack
        [SerializeField] ParticleSystem introEffect; //Effect for Boss intro in Scene
    
        [SerializeField] CharacterHealth playerHealth;
        public GameObject playerTarget;
        private Vector3 actualCpTarget;
        private float distanceEnemyPlayer;

        // Start is called before the first frame update
        void Start()
        {
            bossHealth = GetComponent<BossHealth>();
            boss = GetComponent<NavMeshAgent>();
            playerTarget = GameObject.FindWithTag("Player");
            bossState = GetComponent<Animator>();
            fireRateTime = initFireRateTime;
            waitTime = initWaitTime;
            fireBallTime = initFireBallTime;
            pathBossIndex = Random.Range(0, pathBoss.Length);
        }

        // Update is called once per frame
        void Update()
        {
            switch (bossHealth.getNPhase())
            {
                //First stage of Boss
                case 1:
                    rangeAttack = 3.0f;
                    rangeAlert = 10.0f;
                    firstPhase();
                    break;
            
                //Second stage of Boss
                case 2:
                    rangeAttack = 10.0f;
                    rangeAlert = 20.0f;
                    secondPhase();
                    break;
            }

        }
    
        private void firstPhase()
        {
            if (bossHealth.health > 0)
            {
                float distance = Vector3.Distance(playerTarget.transform.position, transform.position);

                if (distance > rangeAlert)
                {
                    IdleStateMode();
                }
                else
                {
                    FollowPlayer();
                }
            }
        }

        private void secondPhase()
        {
            stick.SetActive(false);
            //If Boss is alive
            if (bossHealth.health > 0)
            {
                //distance between boss and player
                float distance = Vector3.Distance(playerTarget.transform.position, transform.position);

                // Setup the struct fighting, attack and follower for Boss Second Stage
                if (distance > rangeAlert)
                {
                    Debug.Log("diocane1");
                    IdleStateMode();
                }
                else
                {
                    Debug.Log("porcodio2");
                    FollowPlayer();
                }
            }
        }

        private void IdleStateMode()
        {
            boss.SetDestination(pathBoss[pathBossIndex].position);
        
            if (waitTime <= 0)
            {
                pathBossIndex = Random.Range(0, pathBoss.Length);
                waitTime = initWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        private void FollowPlayer()
        {
            //Set distance offset between enemy ai and player
            float distance = Vector3.Distance(playerTarget.transform.position, transform.position);
        
            if (distance <= rangeAttack && playerHealth.health > 0)
            { //Distance between Enemy and Player is lower than 1
                AttackState();
            }

            else if (distance <= rangeAlert && playerHealth.health > 0)
            { //Distance between Enemy and Player is lower than 10
                AlertState();
            }
        }

        void AlertState()
        {
            if(bossHealth.getNPhase() == 1)
            {
                bossState.SetBool("isAlert", true);
            }
            else 
            { 
                bossState.SetBool("isAlert2", true);
            }
            
            boss.SetDestination(playerTarget.transform.position);
        }

        void AttackState()
        {
            if(bossHealth.getNPhase() == 1)
                bossState.SetBool("isAttack", true);
            else 
                bossState.SetTrigger("isShooting");
        }

        //called as an event
        private void Shoot()
        { 
            GameObject currentFireBall = Instantiate(fireBall, spherePos.position, spherePos.rotation);
            
            Rigidbody rigidbody = currentFireBall.GetComponent<Rigidbody>();
            rigidbody.AddForce(spherePos.forward * fireBallVelocity, ForceMode.Impulse);
        }

        void stopAttack()
        {
            bossState.SetBool("isAttack", false);
        }

        void ShowBlood()
        {
            bloodSplatter.Play();
        }
    
        void StopBlood()
        {
            bloodSplatter.Stop();
        }

        void ShowAttack()
        {
            attackEffect.Play(true);
        }

        void showIntro()
        {
            introEffect.Play();
        }
    }
}