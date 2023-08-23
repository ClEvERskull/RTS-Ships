using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    MouseManager manager;
    PlayerHealt health;
    Turn Turn;
    public int orgx;
    public int orgy;
    public int x;
    public int y;
    public int shoot;
    public static bool enemyTurn=true;
    public static bool finishTurn = true;
    public static bool enemyGO = false;
    public bool shooted;
    public ParticleSystem shootSmoke;
    int turn=1;
    public static int difference = 0;
    public static bool canAttack = false;
    public bool endShoot = true;
    public static Vector3 dest;
    GameObject destTile;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public GameObject enemyObject;
    GameObject player;


	void Start () {
        orgx = spawner.originx;
        orgy = spawner.originy;
        player = GameObject.Find("player");
        canAttack = false;
        enemyTurn = true;
        finishTurn = true;
    }
	
	 void Update () {
        GameObject tile = GameObject.Find("Hex_" + orgx + "_" + orgy);
        if (tile != null)
        {
            MeshRenderer tileColor = tile.GetComponentInChildren<MeshRenderer>();
            if (tileColor.material.color == Color.red)
            {
                canAttack = true;
            }
            else canAttack = false;
        }

        if ((enemyTurn == true) & (finishTurn == true) & (MouseManager.endTurn == true))
        {
            x = MouseManager.x;
            y = MouseManager.y;
            if (((y+9) < orgy) & (y < orgy))
            {
                turn = 3;
                
                if (orgy % 2 == 1)
                {
                    orgy = orgy - 3 * turn;
                    if (x < orgx)
                    {
                        orgx = orgx - 4;
                        destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                        dest = destTile.transform.position;
                        finishTurn = false;
                        enemyGO = true;
                        Turn.turn = 0;
                    }
                    else if (x > orgx)
                    {
                        orgx = orgx + 4;
                        destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                        dest = destTile.transform.position;
                        transform.position = dest;
                        Turn.turn = 0;
                    }
                    else if (x == orgx)
                    {
                        destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                        dest = destTile.transform.position;
                        transform.position = dest;
                        Turn.turn = 0;
                    }
                }
                else if(orgy%2==0)
                {
                    orgy = orgy - 3 * turn;
                    if (x < orgx)
                    {
                        orgx = orgx - 5;
                        destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                        dest = destTile.transform.position;
                        finishTurn = false;
                        enemyGO = true;
                        Turn.turn = 0;
                    }
                    else if (x > orgx)
                    {
                        orgx = orgx + 5;
                        destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                        dest = destTile.transform.position;
                        finishTurn = false;
                        enemyGO = true;
                        Turn.turn = 0;
                    }
                    else if (x == orgx)
                    {
                        destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                        dest = destTile.transform.position;
                        finishTurn = false;
                        enemyGO = true;
                        Turn.turn = 0;
                    }
                }
                
                
            }
            else if (((y+9) >= orgy) & (y <= orgy))
            {
                if ((y + 6) <= orgy)
                {
                    turn = 2;
                    orgy = orgy - 3 * turn;
                    destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                    dest = destTile.transform.position;
                    finishTurn = false;
                    enemyGO = true;
                    if ((x + 3) <= orgx)
                    {
                        orgx = orgx - 3;
                        destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                        dest = destTile.transform.position;
                        finishTurn = false;
                        enemyGO = true;
                        Turn.turn = 0;
                    }
                    else if ((x - 3) >= orgx)
                    {
                        orgx = orgx + 3;
                        destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                        finishTurn = false;
                        enemyGO = true;
                        Turn.turn = 0;
                    }
                    else if (((x + 3) >= orgx) & ((x - 3) <= orgx))
                    {
                        finishTurn = true;
                        shoot = 1;
                        //enemyAttack();
                        endShoot = false;
                        Turn.turn = 0;
                    }

                }
                else if ((y + 3) <= orgy)  
                {
                    turn = 1;
                    orgy = orgy - 3 * turn;
                    destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                    dest = destTile.transform.position;
                    finishTurn = false;
                    enemyGO = true;
                    if ((x + 6) <= orgx)
                    {
                        orgx = orgx - 6;
                        destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                        dest = destTile.transform.position;
                        finishTurn = false;
                        enemyGO = true;
                        Turn.turn = 0;
                    }
                    else if (((x + 6) >= orgx) & ((x + 3) <= orgx))
                    {
                        orgx = orgx - 3;
                        destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                        dest = destTile.transform.position;
                        finishTurn = false;
                        enemyGO = true;
                        shoot = 1;
                        //enemyAttack();
                        endShoot = false;
                        Turn.turn = 0;
                    }
                    else if (((x + 3) >= orgx) & ((x - 3) <= orgx))
                    {
                        shoot = 2;
                        //enemyAttack();
                        endShoot = false;
                        finishTurn = true;
                        Turn.turn = 0;
                    }
                    else if ((x - 6) >= orgx) 
                    {
                        orgx = orgx + 6;
                        destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                        dest = destTile.transform.position;
                        finishTurn = false;
                        enemyGO = true;
                        shoot = 1; 
                        //enemyAttack();
                        endShoot = false;
                        Turn.turn = 0;
                    }
                    else if (((x - 6) <= orgx) & ((x + 3) <= orgx))
                    {
                        orgx = orgx + 3;
                        destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                        dest = destTile.transform.position;
                        finishTurn = false;
                        enemyGO = true;
                        shoot = 1; 
                        //enemyAttack();
                        endShoot = false;
                        Turn.turn = 0;
                    }
                }

                else if (((y + 3) >= orgy) & ((y-3)<=orgy))
                {
                    if ((x + 9) <= orgx)
                    {
                        orgx = orgx - 9;
                        destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                        dest = destTile.transform.position;
                        finishTurn = false;
                        enemyGO = true;
                        Turn.turn = 0;
                    }
                    else if (((x + 9) >= orgx) & ((x + 6) < orgx))
                    {
                        orgx = orgx - 6;
                        destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                        dest = destTile.transform.position;
                        finishTurn = false;
                        enemyGO = true;
                        shoot = 1;
                        //enemyAttack();
                        endShoot = false;
                        Turn.turn = 0;
                    }
                    else if (((x + 6) >= orgx) & ((x + 3) < orgx))
                    {
                        orgx = orgx - 3;
                        destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                        dest = destTile.transform.position;
                        finishTurn = false;
                        enemyGO = true;
                        shoot = 2;
                        //enemyAttack();
                        endShoot = false;
                        Turn.turn = 0;
                    }
                    else if (((x + 3) >= orgx) & ((x - 3) <= orgx))
                    {
                        finishTurn = true;
                        shoot = 3;
                        //enemyAttack();
                        endShoot = false;
                        Turn.turn = 0;
                    }
                    else if ((x - 9) > orgx) 
                    {
                        orgx = orgx + 9;
                        destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                        dest = destTile.transform.position;
                        finishTurn = false;
                        enemyGO = true;
                        Turn.turn = 0;
                    }
                    else if (((x - 9) <= orgx) & ((x - 6) > orgx))
                    {
                        orgx = orgx + 6;
                        destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                        dest = destTile.transform.position;
                        finishTurn = false;
                        enemyGO = true;
                        shoot = 1; 
                        //enemyAttack();
                        endShoot = false;
                        Turn.turn = 0;
                    }
                    else if (((x - 6) <= orgx) & ((x - 3) > orgx))
                    {
                        orgx = orgx + 3;
                        destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                        dest = destTile.transform.position;
                        finishTurn = false;
                        enemyGO = true;
                        shoot = 2;
                        //enemyAttack();
                        endShoot = false;
                        Turn.turn = 0;
                    }
                }
            }

            else if (((y - 9) > orgy) & (y > orgy))
            {
                turn = 3;
                if (orgy % 2 == 1)
                {
                    orgy = orgy + 3 * turn;
                    if (x < orgx)
                    {
                        orgx = orgx - 4;
                        destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                        dest = destTile.transform.position;
                        finishTurn = false;
                        enemyGO = true;

                        Turn.turn = 0;
                    }
                    else if (x > orgx)
                    {
                        orgx = orgx + 4;
                        destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                        dest = destTile.transform.position;
                        finishTurn = false;
                        enemyGO = true;
                        Turn.turn = 0;
                    }
                    else if (x == orgx)
                    {
                        destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                        dest = destTile.transform.position;
                        finishTurn = false;
                        enemyGO = true;
                        Turn.turn = 0;
                    }
                }
                else
                {
                    orgy = orgy + 3 * turn;
                    if (x < orgx)
                    {
                        orgx = orgx - 5;
                        destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                        dest = destTile.transform.position;
                        finishTurn = false;
                        enemyGO = true;
                        Turn.turn = 0;
                    }
                    else if (x > orgx)
                    {
                        orgx = orgx + 5;
                        destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                        dest = destTile.transform.position;
                        finishTurn = false;
                        enemyGO = true;
                        Turn.turn = 0;
                    }
                    else if (x == orgx)
                    {
                        destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                        dest = destTile.transform.position;
                        finishTurn = false;
                        enemyGO = true;
                        Turn.turn = 0;
                    }
                }
            }
            else if (((y - 9) <= orgy) & (y > orgy))
            {
                if ((y - 6) > orgy)
                {
                    turn = 2;
                    orgy = orgy + 3 * turn;
                    destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                    dest = destTile.transform.position;
                    finishTurn = false;
                    enemyGO = true;
                    if ((x + 3) <= orgx)
                    {
                        orgx = orgx - 3;
                        destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                        dest = destTile.transform.position;
                        finishTurn = false;
                        enemyGO = true;
                        Turn.turn = 0;
                    }
                    else if (((x + 3) >= orgx) & ((x - 3) >= orgx))
                    {
                        orgx = orgx + 3;
                        destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                        dest = destTile.transform.position;
                        finishTurn = false;
                        enemyGO = true;
                        Turn.turn = 0;
                    }
                    else if (((x + 3) >= orgx) & ((x - 3) <= orgx))
                    {
                        shoot = 1;
                        //enemyAttack();
                        endShoot = false;
                        Turn.turn = 0;
                    }
                }
                else if ((y - 6) < orgy)
                {
                    turn = 2;
                    orgy = orgy + 3 * turn;
                    destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                    dest = destTile.transform.position;
                    finishTurn = false;
                    enemyGO = true;
                    if ((x + 3) <= orgx)
                    {
                        orgx = orgx - 3;
                        destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                        dest = destTile.transform.position;
                        finishTurn = false;
                        enemyGO = true;
                        Turn.turn = 0;
                    }
                    else if (((x + 3) >= orgx) & ((x - 3) >= orgx))
                    {
                        orgx = orgx + 3;
                        destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                        dest = destTile.transform.position;
                        finishTurn = false;
                        enemyGO = true;
                        Turn.turn = 0;
                    }
                    else if (((x + 3) >= orgx) & ((x - 3) <= orgx))
                    {
                        shoot = 1;
                        //enemyAttack();
                        endShoot = false;
                        Turn.turn = 0;
                        finishTurn = true;
                    }
                }


                else if ((y - 3) <= orgy)
                {
                    turn = 1;
                    orgy = orgy + 3 * turn;
                    destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                    dest = destTile.transform.position;
                    finishTurn = false;
                    enemyGO = true;
                    if ((x + 6) <= orgx)
                    {
                        orgx = orgx - 6;
                        destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                        dest = destTile.transform.position;
                        finishTurn = false;
                        enemyGO = true;
                        Turn.turn = 0;
                    }
                    else if (((x + 6) >= orgx) & ((x + 3) <= orgx))
                    {
                        orgx = orgx - 3;
                        destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                        dest = destTile.transform.position;
                        finishTurn = false;
                        enemyGO = true;
                        shoot = 1;
                        //enemyAttack();
                        endShoot = false;
                        Turn.turn = 0;
                    }
                    else if (((x + 3) >= orgx) & ((x-3) <= orgx))
                    {
                        shoot = 2;
                        //enemyAttack();
                        endShoot = false;
                        finishTurn = true;
                        Turn.turn = 0;
                    }

                    else if ((x - 6) > orgx)
                    {
                        orgx = orgx + 6;
                        destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                        dest = destTile.transform.position;
                        finishTurn = false;
                        enemyGO = true;
                        Turn.turn = 0;
                    }
                    else if (((x - 6) <= orgx) & ((x - 3) >= orgx))
                    {
                        orgx = orgx + 3;
                        destTile = GameObject.Find("Hex_" + orgx + "_" + orgy);
                        dest = destTile.transform.position;
                        finishTurn = false;
                        enemyGO = true;
                        shoot = 1;
                        //enemyAttack();
                        endShoot = false;
                        Turn.turn = 0;
                    }
                    
                }
            }


        }

        if(((y-1)==orgy) || ((y+1)==orgy)) {
            if (x == orgx)
            {
                difference = 10;
            }
            else if (((x + 1) == orgx) || ((x - 1) == orgx))
            {
                difference = 9;
            }
            else if (((x + 2) == orgx) || ((x - 2) == orgx))
            {
                difference = 8;
            }
            else if (((x + 3) == orgx) || ((x - 3) == orgx))
            {
                difference = 7;
            }

        }
        else if (((y - 2) == orgy) || ((y + 2) == orgy))
        {
            if (x == orgx)
            {
                difference = 6;
            }
            else if (((x + 1) == orgx) || ((x - 1) == orgx))
            {
                difference = 5;
            }
            else if (((x + 2) == orgx) || ((x - 2) == orgx))
            {
                difference = 4;
            }
            else if (((x + 3) == orgx) || ((x - 3) == orgx))
            {
                difference = 3;
            }

        }
        else if (((y - 3) == orgy) || ((y + 3) == orgy))
        {
            if (x == orgx)
            {
                difference = 2;
            }
            else if (((x + 1) == orgx) || ((x - 1) == orgx))
            {
                difference = 1;
            }
            else if (((x + 2) == orgx) || ((x - 2) == orgx))
            {
                difference = 0;
            }
            else if (((x + 3) == orgx) || ((x - 3) == orgx))
            {
                difference = -1;
            }

        }
        if ((endShoot == false) & (enemyGO == false))
        {
            enemyAttack();
            endShoot = true;
            Turn.turn = 0;
        }


        if((orgx == x) & (orgy == y))
        {
            destTile = GameObject.Find("Hex_" + (orgx + 1) + "_" + orgy);
            dest = destTile.transform.position;
            finishTurn = false;
            enemyGO = true;
            Turn.turn = 0;
        }
    }

    void enemyAttack()
    {
            for (int i = 0; i < shoot; i++)
            {
                InvokeRepeating("launchShoot", i, 0);
            }
            Turn.turn = 0;
    }

    void launchShoot()
    {
        var scope = Unit.poloha;
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        enemyObject.transform.LookAt(scope);
        bullet.transform.LookAt(scope);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 10;
        Destroy(bullet, 7.0f);
        shootSmoke.Play();
    }


}

