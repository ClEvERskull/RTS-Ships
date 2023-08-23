using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceText : MonoBehaviour {

    Enemy enemysNumbers;
    public int distanceX;
    public int distanceY;
    public int playerX;
    public int playerY;
    public int enemyX;
    public int enemyY;
    public int distance;
    public Text distanceText;

	// Use this for initialization
	void Start () {
		
	}
	
	
	void Update () {
        enemyX = enemysNumbers.orgx;
        enemyY = enemysNumbers.orgy;
        playerX = MouseManager.x;
        playerY = MouseManager.y;
        distanceX = enemyX - playerX;
        distanceY = enemyY - playerY;
        distance = ((distanceX * distanceX) + (distanceY * distanceY)) / distance;
        distanceText.text = distance + " Tiles";
    }
}
