using UnityEngine;

public class BulletLife : MonoBehaviour
{
    public float bulletLife = 300.0f; // 5 sec for now

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bulletLife--;

        if(bulletLife <= 0)
        {
            Destroy(gameObject);
        }
    }
}
