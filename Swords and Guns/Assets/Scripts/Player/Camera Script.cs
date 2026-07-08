using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    private const float YMin = -65.0f;
    private const float YMax = 65.0f;

    public Transform lookAt;
    public Transform Player;

    [SerializeField] PlayerInput input;

    public float distance = 10.0f;
    Vector2 currentPos;
    public float sensivity = 4.0f;

    void LateUpdate()
    {
        currentPos += input.actions["Look"].ReadValue<Vector2>();

        currentPos.y = Mathf.Clamp(currentPos.y, YMin, YMax);

        Vector3 Direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentPos.y, currentPos.x, 0);
        transform.position = lookAt.position + rotation * Direction;

        transform.LookAt(lookAt.position);

     

    }
}