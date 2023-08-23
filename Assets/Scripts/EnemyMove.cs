using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    public GameObject enemyPlayer;
    Vector3 destination;
    Enemy enemy;
    public ParticleSystem waves;
    public bool wave = false;
	// Use this for initialization
	void Start () {
        destination = Enemy.dest;
        waves.Stop();
    }

    // Update is called once per frame
    void Update() {
        destination = Enemy.dest;
        if ((Enemy.enemyGO == true) & (enemyPlayer.transform.position != destination))
        {
            wave = true;
            enemyPlayer.transform.LookAt(destination);
            transform.position = Vector3.MoveTowards(transform.position, destination, 7 * Time.deltaTime);
            
            if (transform.position == destination)
            {
                wave = false;
                Enemy.finishTurn = true;
                Enemy.enemyGO = false;
                waves.Stop();
            }
            else if ((wave == true) & (waves.isPlaying == false))
            {
                waves.Play();
            }
        }
    
    }
}
