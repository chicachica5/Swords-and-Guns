using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    float speed = 0.10f;
    float turnSpeed = 1.0f;
    public float vSpeed = 0.0f; //current vertical speed
    float jumpSpeed = 4.0f;
    float gravity = 0.14f;

    Vector2 movement;
    bool isRunning = false;


    [SerializeField] Camera cam;
    [SerializeField] Animator animator;
    [SerializeField] PlayerInput input;
    [SerializeField] CharacterController rb;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        //horizontal movement
        movement = input.actions["Move"].ReadValue<Vector2>();
        transform.rotation = Camera.main.transform.rotation;
        if(movement.x == 0 && movement.y == 0)
        {
            animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetBool("isMoving", true);
        }

        if(rb.isGrounded) 
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
        
        vSpeed -= gravity;
        rb.Move(new Vector3(movement.x, vSpeed, movement.y)*speed);
    }

    public void OnJump()
    {
        
    }

    public void OnSprint()
    {
        isRunning = true;
        animator.SetBool("isRunning", isRunning);
    }
}
