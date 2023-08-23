using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    
    public GameObject coin;
    public GameObject player;

    void Start()
    {
        player = GameObject.Find("player");
    }

    void Update()
    {
        transform.Rotate(Vector3.up * 2, Space.World);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("Collision!!!");
            Cash.cash++;
            Destroy(transform.parent.gameObject);
        }
        
    }
}
