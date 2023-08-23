using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillText : MonoBehaviour {
    public Text kills;
    public static int killCounter;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        kills.text = "Killed enemies : " + (killCounter);
    }
}
