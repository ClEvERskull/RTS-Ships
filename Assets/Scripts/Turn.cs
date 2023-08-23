using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour {
    public static int turn=0;
    public static bool yourTurn = true;
    public Canvas canvas;
    Enemy enemy;
    public GameObject bullet;

    // Use this for initialization
    void Start()
    {
        turn = 0;
    }
    void Update () {
        bullet = GameObject.Find("Bullet(Clone)");

        if (turn == 0) 
        {
            Enemy.enemyTurn = false;
            if ((Enemy.enemyTurn == false) & (Enemy.finishTurn == true) & (bullet == null))
            {
                MouseManager.endTurn = false;
                yourTurn = true;
            }
        }
       
        else if ((turn == 3) & (PlayerHealt.enemyDefeated != true) & (EnemyHealth.willBeDestroyed == false))
        {
            yourTurn = false;
            if (bullet == null)
            {
                Enemy.enemyTurn = true;
            }
        }
        /*if ((yourTurn == false) & (bullet == null))
        {
            Enemy.enemyTurn = true;
        }*/
    }

	
	// Update is called once per frame
	
}
