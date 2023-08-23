using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour {
    public GameObject pointer;
    public GameObject enemyObject;
    public GameObject pirateEnemy;
    Vector3 direction;
    
    void Update () {

        enemyObject = GameObject.Find("enemy");
        if (PlayerHealt.enemyDefeated != true)
        {
            if (enemyObject != null)
            {
                direction = enemyObject.transform.position;
                pointer.transform.LookAt(direction);
            }
        }
        else
        {
            transform.Rotate(Vector3.up * 5, Space.World);
        }
	}
}
