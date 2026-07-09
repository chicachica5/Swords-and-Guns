using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    void FixedUpdate()
    {
        var aux = player.transform.position;
        aux.y = transform.position.y;
        transform.LookAt(aux);
    }
}
