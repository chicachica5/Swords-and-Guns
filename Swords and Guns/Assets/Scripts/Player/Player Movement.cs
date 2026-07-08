using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    float speed = 0.10f;
    //float turnSpeed = 1.0f;
    public float vSpeed = 0.0f; //current vertical speed
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


        //set rotation equal to camera, x rotation set to 0
        Vector3 tmp = Camera.main.transform.localEulerAngles;
        tmp.x = 0;
        transform.localEulerAngles = tmp;// = Camera.main.transform.rotation;
    
        
        float angle = gameObject.transform.localEulerAngles.y;
       
        movement = new Vector2() * movement;
        //maybe
        /*
        public Vector2 Vector2FromAngle(float a)
    {
        a *= Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(a), Mathf.Sin(a));
    }*/
        if(movement.x == 0 && movement.y == 0) //set for animation
        {
            animator.SetBool("isMoving", false);
        }
        else 
        {
            animator.SetBool("isMoving", true);
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
