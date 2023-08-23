using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileSystem : MonoBehaviour {

    MouseManager manager;
    Hex hex;
    public Canvas Canvas;

    public void tiles () {
            for (int xm = 1; xm <= 2; xm++)
        {
            for (int ym = 1; ym <= 3; ym++)
            {
                GameObject minusNeighbor = GameObject.Find("Hex_" + (1 * xm) + "_" + (1 * ym));
                MeshRenderer minus = minusNeighbor.GetComponentInChildren<MeshRenderer>();
                minus.material.color = Color.blue;
                GameObject plusNeighbor = GameObject.Find("Hex_" + (1 * xm) + "_" + (1 * ym));
                MeshRenderer plus = plusNeighbor.GetComponentInChildren<MeshRenderer>();
                plus.material.color = Color.blue;

            }

        }
        //Canvas.gameObject.SetActive(false);
    }
	
}
