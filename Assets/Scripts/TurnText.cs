using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnText : MonoBehaviour {
    public Text turn;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Turn.yourTurn == true) {
            turn.text = "Turn " + (Turn.turn+1) + " of 3";
        }
        else if (Turn.yourTurn == false) {
            turn.text = "Enemy turn!!!";
        }
	}
}
