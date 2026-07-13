using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public bool haveTriggered = false;

    void OnTriggerEnter(Collider other) 
    {
        if(!haveTriggered)
        {
        if(other.gameObject.tag == "Player")
            {
                Stat monsterDamage = gameObject.transform.parent.GetComponent<Entity>().GetEntityStat("Damage");

                EntityHealthManager hp = other.gameObject.GetComponent<EntityHealthManager>();

                hp.ChangeHealth(monsterDamage.stat);
                haveTriggered = true;
                Debug.Break();
            }
        }
    }
}
