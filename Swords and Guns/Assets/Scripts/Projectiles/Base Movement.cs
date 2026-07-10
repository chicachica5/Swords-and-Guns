using UnityEngine;

public class BaseMovement : MonoBehaviour
{
    float speed = 0.3f; //base speed for some reason

    void FixedUpdate()
    {
        transform.position += transform.rotation*Vector3.forward*speed;
    }

    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
