using UnityEngine;

public class EntityHealthManager : MonoBehaviour
{
    private int Health = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Entity en = gameObject.GetComponent<Entity>();
        Health = en.GetEntityStat("Health").stat;
    }

    public void ChangeHealth(int dmg)
    {
        Health -= dmg;
        CheckHealth();
    }

    private void CheckHealth()
    {
        if(Health <= 0)
        {
            //Ded, for now destroy
            Destroy(gameObject);
        }
    }
}
