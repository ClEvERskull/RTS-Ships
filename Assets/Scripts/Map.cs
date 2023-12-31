using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {
 

    public GameObject hexPrefab;

    public GameObject moneyPrefab;
    GameObject moneyPosition;
    public GameObject money;
    public Transform coinParent;

    int height = 42;
    int width = 42;
    float xOffset = 6.94f;
    float zOffset = 6.02f;

    void Start () {
        for(int x=0;x<width;x++)
        {           
            for (int y=0;y<height;y++)
            {
                float xPos = x * xOffset;
                //Sme v neparnom riadku
                if(y % 2 == 1)
                {
                    xPos += xOffset/2f;
                }
                GameObject hex_go = (GameObject)Instantiate(hexPrefab, new Vector3(xPos, 0, y * zOffset), Quaternion.identity);

				//Kod pre priradzovanie mena jednotlivym dlazdicam
                hex_go.name = "Hex_" + x + "_" + y;
                hex_go.GetComponent<Hex>().x = x;
                hex_go.GetComponent<Hex>().y = y;
                //Kod pre ukladanie dlazdic pod rodicovsky objekt(Map)
                hex_go.transform.SetParent(this.transform);
                hex_go.isStatic = true;
            }
        }
        spawner.mapDone = true;

        for (int moneycounter = 0; moneycounter < 100; moneycounter++)
        {
            int moneyx = Random.Range(0, 42);
            int moneyy = Random.Range(0, 42);
            moneyPosition = GameObject.Find("Hex_" + moneyx + "_" + moneyy);
            money = Instantiate(moneyPrefab, moneyPosition.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            money.name = "money_" + moneycounter;
            money.transform.SetParent(coinParent);
        }
    }

    void Update()
    {
        
    }
}
