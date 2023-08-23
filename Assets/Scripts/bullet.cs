using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    
    public GameObject shoot;
    public GameObject player;
    public GameObject enemy;

    void Awake()
    {
        shoot.GetComponent<Collider>();
        player = GameObject.Find("player");
        enemy = GameObject.Find("enemy");
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == player)
        {
            Destroy(shoot);
            PlayerHealt.damaged = true;
            EnemyHealth.takeDamage = false;
        }

        else if (other.gameObject == enemy)
        {
            Destroy(shoot);
            PlayerHealt.damaged = false;
            EnemyHealth.takeDamage = true;
        }
    }
}
