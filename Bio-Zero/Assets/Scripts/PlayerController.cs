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

   [SerializeField] private float smoothTime = 0.05f;
   private float currentVelocity;

   [SerializeField] private float speed;

   private float gravity = -9.81f;
   [SerializeField] private float gravityMultiplier = 3.0f;
   private float velocity;
   [SerializeField] private float jumpPower;
   
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
        direction.y = velocity;
       
   }
   private void ApplyMovement()
   {
        controller.Move(direction * speed * Time.deltaTime);
   }
   private void ApplyRotation()
   {
        if(input.sqrMagnitude == 0) 
        {
            animator.SetBool("isRunning", false);
            return;
        }

        animator.SetBool("isRunning", true);
        var targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);

        
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
        else if(controller.isGrounded)
        { 
            animator.SetBool("isJumping", true);
            velocity += jumpPower;
        }
        if(!controller.isGrounded) return;
        
       
   }
}