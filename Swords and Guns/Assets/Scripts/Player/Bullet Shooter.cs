using UnityEngine;
using UnityEngine.InputSystem;

public class BulletShooter : MonoBehaviour
{   
    [SerializeField] GameObject ShootPosition;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] PlayerInput input;

    void Update()
    {

    }

    private void Shoot()
    {
        GameObject b = Instantiate(bulletPrefab, ShootPosition.transform.position, gameObject.transform.rotation);
        b.GetComponent<BaseMovement>().setSpeed(1.0f);
    }

    void OnShoot()
    {
       Shoot();
    }
}
