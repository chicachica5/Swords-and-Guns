using UnityEngine;
using UnityEngine.InputSystem;

public class BulletShooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] PlayerInput input;

    void Update()
    {

    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.identity);
        
    }

    void OnShoot()
    {
        Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.identity);
    }
}
