using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    float speed = 0.01f;
    Vector2 movement;
    bool isRunning = false;
    bool isJumping = false;

    [SerializeField] Animator animator;
    [SerializeField] PlayerInput input;
    void Start()
    {
        
    }

    void Update()
    {
        movement = input.actions["Move"].ReadValue<Vector2>();
        if(movement.x != 0 || movement.y != 0)
        {
            animator.SetBool("isMoving", true);
            transform.position += new Vector3(movement.x, 0.0f, movement.y)*speed;
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    public void OnJump()
    {
        isJumping = true;
        animator.SetBool("isJumping", isJumping);
    }

    public void OnSprint()
    {
        isRunning = true;
        animator.SetBool("isRunning", isRunning);
    }
}
