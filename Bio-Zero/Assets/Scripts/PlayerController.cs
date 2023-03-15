using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
   private Vector2 input;
   private CharacterController controller;
   private Animator animator;
   private Vector3 direction;
   private Vector3 moveDir;

    public Transform cam;

   [SerializeField] private float smoothTime = 0.05f;
   private float currentVelocity;

   [SerializeField] private float speed;

   private float gravity = -9.81f;
   [SerializeField] private float gravityMultiplier = 3.0f;
   private float velocity;
   [SerializeField] private float jumpPower;
   private bool isJumping = false;
   private float targetAngle = 0.0f;
   
   private void Awake() 
   {
        controller = GetComponent<CharacterController>(); 
        animator = GetComponent<Animator>();
   }
   private void Update() 
   {
        ApplyRotation();
        ApplyMovement();
        ApplyGravity();
   }
   private void ApplyGravity()
   {
        if(controller.isGrounded && velocity < 0.0f )
        {
            //reset the velocity when the character touch the ground
            velocity = -1.0f;
        }
        else 
        {
            velocity += gravity * gravityMultiplier * Time.deltaTime;
            
        } 
        moveDir.y = velocity;
   }
   private void ApplyMovement()
   {
        controller.Move(moveDir.normalized * (speed * Time.deltaTime) + new Vector3(0.0f, velocity, 0.0f) * Time.deltaTime);
   }
   private void ApplyRotation()
   {
        if(input.sqrMagnitude == 0) 
        {
            jump();
            moveDir = Vector3.zero;
            animator.SetBool("isRunning", false);
            return;
        }

        if(input.magnitude != 0)
        {
            animator.SetBool("isRunning", true);
            targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref currentVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
        }

        moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        jump();
   }
   public void Move(InputAction.CallbackContext context)
   {
        input = context.ReadValue<Vector2>();
        direction = new Vector3(input.x, 0.0f, input.y);
   }
   public void Jump(InputAction.CallbackContext context)
   {
        if(!context.started)  
        {
            animator.SetBool("isJumping", false);
            return;
        }
        else
        {
            isJumping = true;
            
        }
        if(!controller.isGrounded) return;
        
       
   }

   private void jump()
   {
    if(isJumping && controller.isGrounded)
    {
        //this formulae calculate how much velocity needed to reach desired height
        velocity += Mathf.Sqrt(jumpPower * -2f * gravity);;
        animator.SetBool("isJumping", true);
        animator.SetBool("isGrounded", true);
    }
    isJumping = false;
   }
}