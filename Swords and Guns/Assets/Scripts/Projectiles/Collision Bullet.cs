using UnityEngine;

public class CollisionBullet : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        Stat playerDmg = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<Entity>().GetEntityStat("BulletDamage");
        
        EntityHealthManager hp = other.gameObject.GetComponent<EntityHealthManager>();

        hp.ChangeHealth(playerDmg.stat);
        Destroy(gameObject);
    }

}
