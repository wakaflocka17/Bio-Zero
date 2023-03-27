using UnityEngine;
using UnityEngine.AI;

public class BossAIMovement : MonoBehaviour
{
    private NavMeshAgent boss; //Enemy object
    private Animator bossState; //States Animation Enemy
    
    public Transform[] pathBoss; //Transform path for Boss
    private int pathBossIndex;
    private int index;
    
    private float waitTime;
    private float initWaitTime = 05.0f;
    
    private float rangeAlert = 10.0f; //Range for set true the Alert flag
    private float rangeAttack = 03.0f; //Range for set true the Attack flag
    
    private BossHealth bossHealth;
    [SerializeField] float gravity = -9.81f; //Gravity to apply to boss
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
        waitTime = initWaitTime;
        pathBossIndex = Random.Range(0, pathBoss.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
        ResetAnimatorState(bossState);

        if(bossHealth.health > 0)
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
        
        else
        {
            bossState.SetBool("isDead", true);
        }
        
    }

    private void IdleStateMode()
    {
        boss.SetDestination(pathBoss[pathBossIndex].position);

        if (waitTime <= 0)
        {
            bossState.SetBool("isWalking", true);
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
        distanceEnemyPlayer = Vector3.Distance(transform.position, playerTarget.transform.position);
        
        if (distanceEnemyPlayer < rangeAttack && playerHealth.health > 0)
        { //Distance between Enemy and Player is lower than 1
            AttackState();
        }
        
        else if (distanceEnemyPlayer < rangeAlert && playerHealth.health > 0)
        { //Distance between Enemy and Player is lower than 10
            AlertState();
        }
    }

    public void ResetAnimatorState(Animator animator)
    {
        animator.SetBool("isAlert", false);
        animator.SetBool("isAttack", false);
    }

    void AlertState()
    {
        bossState.SetBool("isAlert", true);
        boss.SetDestination(playerTarget.transform.position);
    }

    void AttackState()
    {
        bossState.SetBool("isAttack", true);
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