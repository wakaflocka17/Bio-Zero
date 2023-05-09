using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
   CharacterController controller;

   public float moveSpeed = 3;
   [HideInInspector] public Vector3 dir;
   float hzInput, vInput;

   [SerializeField] float gravity = -9.81f; 
   Vector3 velocity;

   MovementBaseState currentState;

   public IdleState Idle = new IdleState();
   public RunningState Run = new RunningState();

   [HideInInspector] public Animator animator;

   CharacterHealth playerHealth;
   private PlayerInfoManager playerInfo;

   private void Start()
   {
  
     playerInfo = GetComponent<PlayerInfoManager>();
     playerHealth = GetComponent<CharacterHealth>();
     animator = GetComponent<Animator>();
     controller = GetComponent<CharacterController>();
     SwitchState(Idle);
     
     
   }
   
   private void Update() 
   {
     if(playerHealth.health > 0)
     {    
        GetDirection();
        Gravity();

        animator.SetFloat("hzInput", hzInput);
        animator.SetFloat("vInput", vInput);
        
        currentState.UpdateState(this);
     }
   }

   private void GetDirection()
   {
     hzInput = Input.GetAxis("Horizontal");
     vInput = Input.GetAxis("Vertical");

     dir = transform.forward * vInput + transform.right * hzInput;
     
     controller.Move(dir.normalized * moveSpeed * Time.deltaTime);
   }

   private void Gravity(){
     if(!controller.isGrounded)
     {
          velocity.y += gravity * Time.deltaTime;
     }
     else if(velocity.y < 0)
     {
          velocity.y = -2;
     }

     controller.Move(velocity * Time.deltaTime);
   }

   public void SwitchState(MovementBaseState state)
   {
     currentState = state;
     currentState.EnterState(this);

   }
  
}