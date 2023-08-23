using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseManager : MonoBehaviour {
    Unit selectedUnit;
    public Canvas Canvas;
    Move Move;
    Turn Turn;
    Hex Hex;
    public static bool endTurn = false;
    public bool shooted = false;
    public ParticleSystem waves;
    public ParticleSystem shootSmoke;
    public static int x;
    public static int y;
    public GameObject player;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    // Use this for initialization
    void Start () {
        Canvas.gameObject.SetActive(false);
        waves.Stop();
        shootSmoke.Stop();
        player = GameObject.Find("Player/player");
        x = 15;
        y = 0;
        KillText.killCounter = 0;
    }

    // Update is called once per frame
    public void Update()
    { 
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

       

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo)) 
            {


            GameObject ourObject = hitInfo.collider.transform.parent.gameObject;
            Debug.Log("Mys nad: " + ourObject.name);
            MeshRenderer render = ourObject.GetComponentInChildren<MeshRenderer>();
            
            if ((ourObject.GetComponent<Hex>() != null) & (Canvas.gameObject.activeSelf == false) & (Turn.yourTurn==true))
            {
                if (render.material.color == Color.blue)
                {
                    moveThere(ourObject);
                }
                if (render.material.color == Color.red)
                {
                    shootThere(ourObject);
                }
            }
            else if (ourObject.GetComponent<Unit>() != null)
            {
                mysNad_Unit(ourObject);
            }
            else if ((ourObject.GetComponent<Enemy>() != null) & (Enemy.canAttack == true))
            {
                shootThere(ourObject);
            }
        }


        if ((shooted == true) & (Canvas.gameObject.activeSelf != false))
        {

            int xmax = x + 4;

            int ymax = y + 4;
            for (int ymin = y - 4; ymin <= ymax; ymin++)
            {
                for (int xmin = x - 4; xmin <= xmax; xmin++)
                {
                    GameObject del = GameObject.Find("Hex_" + xmin + "_" + ymin);
                    if (del != null)
                    {
                        MeshRenderer dlt = del.GetComponentInChildren<MeshRenderer>();
                        if ((dlt.material.color == Color.red) || (dlt.material.color == Color.blue))
                        {
                            dlt.material.color = Color.white;
                        }
                    }
                }
            }
            shooted = false;
        }

        if ((Unit.poloha == selectedUnit.ciel) & (shooted == false))
        {
            waves.Stop();
            if ((Canvas.gameObject.activeSelf != false) || (Turn.yourTurn==false))
            {
                if (Turn.yourTurn == false)
                {
                    endTurn = true;
                }
                else if (Turn.yourTurn == true)
                {
                    endTurn = false;
                }
                int nx=Move.myx;
                int ny=Move.myy;
                
                int xmax = nx + 4;
                
                int ymax = ny + 4;
                for (int ymin=ny-4;ymin<=ymax; ymin++)
                {
                    for (int xmin=nx-4;xmin<=xmax; xmin++)
                    {
                        GameObject del = GameObject.Find("Hex_" + xmin + "_" + ymin);
                        if (del != null)
                        {
                            MeshRenderer dlt = del.GetComponentInChildren<MeshRenderer>();
                            dlt.material.color = Color.white;
                        }
                    }
                }
            }
        }
    }

    

    void mysNad_Unit(GameObject ourObject)
    {
        if (Input.GetMouseButtonDown(0))
        {
            int xmax = x + 4;

            int ymax = y + 4;
            for (int ymin = y - 4; ymin <= ymax; ymin++)
            {
                for (int xmin = x - 4; xmin <= xmax; xmin++)
                {
                    GameObject del = GameObject.Find("Hex_" + xmin + "_" + ymin);
                    if (del != null)
                    {
                        MeshRenderer dlt = del.GetComponentInChildren<MeshRenderer>();
                        if ((dlt.material.color == Color.red) || (dlt.material.color == Color.blue))
                        {
                            dlt.material.color = Color.white;
                        }
                    }
                }
            }
            Canvas.gameObject.SetActive(true);
            selectedUnit = ourObject.GetComponent<Unit>();
        }
    }

    

    void moveThere(GameObject ourObject)
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            x = ourObject.GetComponent<Hex>().x;
            y = ourObject.GetComponent<Hex>().y;
            Turn.turn++;
            selectedUnit.ciel = ourObject.transform.position;
            Canvas.gameObject.SetActive(true);
            waves.Play();
            var destination = ourObject.transform.position;
            player.transform.LookAt(destination);

        }
        
    }

    void shootThere(GameObject ourObject)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Turn.turn++;
            var seen = ourObject.transform.position;
            player.transform.LookAt(seen);
            var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
            bullet.transform.LookAt(seen);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 10;
            Destroy(bullet, 7.0f);
            shooted = true;
            Canvas.gameObject.SetActive(true);
            shootSmoke.Play();
            //shootSmoke.time = 2;
            //shootSmoke.Stop();
        }
    }


}



