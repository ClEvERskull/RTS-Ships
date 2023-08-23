using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

    public GameObject[] whatSpawn;
    GameObject spawnClone;
    GameObject origin;
    public static int originx;
    public static int originy;
    public static bool mapDone = false;
    public GameObject enemyObject;
    public int chooser;

    void Update()
    {
        enemyObject = GameObject.Find("enemy");
        if ((mapDone != false) & (enemyObject == null))
        {
            chooser = Random.Range(0, 6);
                originx = Random.Range(14, 34);
                originy = Random.Range(18, 38);
                origin = GameObject.Find("Hex_" + originx + "_" + originy);
            if ((Move.myx != originx) & (Move.myy != originy))
            {
                spawnClone = Instantiate(whatSpawn[chooser], origin.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            }
        }
    }


}
