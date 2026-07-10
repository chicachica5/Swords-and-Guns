using UnityEngine;

enum chestStates
{
    hide = 0,
    wait,
    follow,
    attack
}

public class ChestBehaviour : MonoBehaviour
{
    chestStates state;
    Transform playerTrans;

    [SerializeField] Animator anim;

    int distanceToFollow = 12;
    int distanceToWait = 4;
    int distanceToMove = 6;

    float chestSpeed = 0.08f;

    void Start()
    {
        state = chestStates.hide;
        playerTrans = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }

    void Update() //here change of states
    {
        float dist = Vector3.Distance(playerTrans.position, gameObject.transform.position);
        
        if (dist < distanceToWait)
        {
            state = chestStates.wait;
            anim.SetBool("isMoving", false);
            anim.SetBool("isHiding", false);
        }
        else if(dist < distanceToFollow && dist > distanceToMove)
        {
            state = chestStates.follow;
            anim.SetBool("isMoving", true);
            anim.SetBool("isHiding", false);
        }
        else if (dist > distanceToMove)
        {
            state = chestStates.hide;
            anim.SetBool("isMoving", false);
            anim.SetBool("isHiding", true);
        }
    }

    void FixedUpdate() //here what happens in states
    {
        switch(state) 
        {
            case chestStates.follow:
                gameObject.transform.position += transform.rotation*Vector3.forward*chestSpeed;
                break;
            default:
                // code block
                break;
        }
    }
}
