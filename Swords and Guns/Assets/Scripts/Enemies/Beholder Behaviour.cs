using UnityEngine;

enum BeholderStates
{
    wait = 0,
    follow,
    wander,
    attackClose,
    attackFar
}

public class BeholderBehaviour : MonoBehaviour
{
    BeholderStates state;
    Transform playerTrans;

    [SerializeField] Animator anim;

    int followDistance = 15;
    int wanderDistance = 10;

    int wanderTime = 120;
    int wanderTimer = 0;
    int wanderDirection = 0; //1 forward, 2 backward, 3 left, 4 right, 5 up, 6 down
    Vector3 movingDir = Vector3.forward;

    float beholderSpeed = 0.15f;
    float wanderSpeed = 0.05f;

    float shootCD = 300;
    float shootTimer = 0;
    public bool isScriptWaiting = false;
    public bool shootTrigger = false;

    public GameObject bulletPrefab;
    public GameObject shootPosition;
    void Start()
    {
        state = BeholderStates.wait;
        playerTrans = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }

    void Update()
    {
        if(isScriptWaiting) return;

        float dist = Vector3.Distance(playerTrans.position, gameObject.transform.position);

        if(shootTimer >= shootCD) 
        {
            anim.SetTrigger("attack");
            anim.SetBool("freeze", true);
            shootTimer = 0;
            isScriptWaiting = true;
        }
        else if(dist < wanderDistance) //set to wander
        {
            state = BeholderStates.wander;

            anim.SetBool("isMoving", true);
            anim.SetInteger("movingState", wanderDirection);
        }
        else if(dist > followDistance) // move to wander distance
        {
            state = BeholderStates.follow;

            SetDirection(1);

            anim.SetBool("isMoving", true);
            anim.SetInteger("movingState", wanderDirection); // 1 is forward
        }
    }

    void FixedUpdate()
    {
        if(isScriptWaiting) return;
        shootTimer++;

        switch(state) 
        {
            case BeholderStates.wander:
                wanderTimer++;
                if(wanderTimer >= wanderTime) 
                {
                    wanderTimer = 0;
                    SetDirection(Random.Range(1, 6));
                    anim.SetInteger("movingState", 1);
                }

                gameObject.transform.position += transform.rotation*movingDir*wanderSpeed;

                
                break;
            case BeholderStates.follow:
                gameObject.transform.position += transform.rotation*movingDir*beholderSpeed;
                break;
            default:
                // code block
                break;
        }
    }

    public void startSecondPhaseAttack()
    {
        anim.SetTrigger("attackSecond");
    }

    void SetDirection(int dir)
    {
        wanderDirection = dir;
        switch(wanderDirection) 
        {
            case 1:
                movingDir = Vector3.forward;
                break;
            case 2:
                movingDir = transform.forward * -1;
                break;
            case 3:
                movingDir = Vector3.left;
                break;
            case 4:
                movingDir = Vector3.right;
                break;
            case 5:
                movingDir = Vector3.up;
                break;
            case 6:
                movingDir = Vector3.down;
                break;
        }
    }

    public void ShootBullet()
    {
        GameObject b = Instantiate(bulletPrefab, shootPosition.transform.position, gameObject.transform.rotation);
        b.GetComponent<BaseMovement>().setSpeed(0.04f);
    }

    public void UnFreeze()
    {
        anim.SetBool("freeze", false);
        isScriptWaiting = false;
    }
}
