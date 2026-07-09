using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    float speed = 0.10f;
    float runSpeed = 0.18f;
    float actualSpeed;
    float vSpeed = 0.0f; //current vertical speed
    float jumpSpeed = 4.0f;
    float gravity = 0.14f;

    Vector2 movement;
    bool isRunning = false;

    [SerializeField] Camera cam;
    [SerializeField] Animator animator;
    [SerializeField] PlayerInput input;
    [SerializeField] CharacterController rb;

    void FixedUpdate()
    {
        //get wasd movement
        movement = input.actions["Move"].ReadValue<Vector2>();
        //temp coding
        float aux = movement.x;
        movement.x = movement.y;
        movement.y = -1*aux;

        //Set speed animator and speed for running or walking
        

        //set rotation equal to camera, x rotation set to 0
        Vector3 tmp = Camera.main.transform.localEulerAngles;
        tmp.x = 0;
        transform.localEulerAngles = tmp;// = Camera.main.transform.rotation;
    
        float angle = Mathf.Deg2Rad*(gameObject.transform.localEulerAngles.y);

        //Did the vector transformation myself
        movement = new Vector2(movement.x*Mathf.Sin(angle) - movement.y*Mathf.Cos(angle),
                                   movement.x*Mathf.Cos(angle) + movement.y*Mathf.Sin(angle)); 


        if(movement.x == 0 && movement.y == 0) //set for animation
        {
            animator.SetBool("isMoving", false);
            animator.SetBool("isRunning", false);
                
        }
        else 
        {
            animator.SetBool("isMoving", true);
            if(input.actions["Sprint"].ReadValue<float>() == 1)
            {
                animator.SetBool("isRunning", true);
                actualSpeed = runSpeed;
            }
            else 
            {
                animator.SetBool("isRunning", false);
                actualSpeed = speed;
            }
        }

        if(rb.isGrounded) //jumping logic, unoptimized, could be improved (same for all this script XD)
        {
            animator.SetBool("isJumping", false);
            vSpeed = 0.0f;

            if(input.actions["Jump"].ReadValue<float>() == 1.0f)
            {
                Debug.Log("A");
                vSpeed = jumpSpeed;
                animator.SetBool("isJumping", true);
            }
        }

        //gravity effect
        vSpeed -= gravity;

        //apply movement to characterbody (rigidboy for player)
        rb.Move(new Vector3(movement.x, vSpeed, movement.y)*actualSpeed);
    }
}
