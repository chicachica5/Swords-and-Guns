using UnityEngine;
using UnityEngine.InputSystem;

public class BulletShooter : MonoBehaviour
{   
    [SerializeField] GameObject ShootPosition;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] PlayerInput input;
    [SerializeField] Camera cam;

    int maxDistance = 500;
    private void Shoot()
    {
        RaycastHit hit = new RaycastHit();
        Vector3 rotation;
        Debug.Log(cam.transform.rotation.eulerAngles);
        if(Physics.Raycast(cam.transform.position, cam.transform.rotation.eulerAngles, maxDistance)) 
        {
            rotation = hit.point - ShootPosition.transform.position;
            Debug.Log(rotation);
        }
        else 
        {
            rotation = (cam.transform.position + cam.transform.rotation*new Vector3(maxDistance, 0.0f, 0.0f)) - ShootPosition.transform.position;
        }
        Quaternion q = new Quaternion();
        q.eulerAngles = rotation.normalized;
        GameObject b = Instantiate(bulletPrefab, ShootPosition.transform.position, q);
        b.GetComponent<BaseMovement>().setSpeed(0.01f);
    }

    void OnShoot()
    {
       Shoot();
    }
}
