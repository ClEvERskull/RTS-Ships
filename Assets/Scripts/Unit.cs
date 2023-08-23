using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    public Vector3 ciel;
    public static Vector3 poloha;
    public GameObject UnitObject;
    MouseManager manager;

    float rych = 7;

	// Use this for initialization
	void Start () {
        ciel = transform.position;
        UnitObject = GameObject.Find("player");
    }
	
	// Update is called once per frame
	void Update () {
        poloha = transform.position;


        //Vector3 smer = ciel - transform.position;
        //Vector3 velocity = smer.normalized * rych * Time.deltaTime;

        //velocity = Vector3.ClampMagnitude(velocity, smer.magnitude);
        //transform.Translate(velocity);
        transform.position = Vector3.MoveTowards(transform.position, ciel, rych*Time.deltaTime);

    }
}
