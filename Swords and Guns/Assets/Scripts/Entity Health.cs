using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    float entityHP = 10; // Set 10 for base

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void checkHealth()
    {
        if(entityHP <= 0.0f) // DEAD
        {
            Debug.Log("Gameobject " + gameObject.name + " is DEAD");
        }
    }

    public void takeHealth(float damage)
    {
        entityHP -= damage;
        checkHealth();
    }

    public void addHealth(float healing)
    {
        entityHP += healing;
        checkHealth();
    }

    public float getHealth() 
    {
        return entityHP;
    }
}
