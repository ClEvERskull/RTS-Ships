using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    MouseManager manager;
    public Canvas Canvas;
    Turn Turn;
    tileSystem tile;
    public static int myx;
    public static int myy;
    Hex hex;
    int ymin;
    int ymax;
    int xmin;
    int xmax;
    GameObject neighbors;
    MeshRenderer minus;

    public void moveToHex()
    {
        myx = MouseManager.x;
        myy = MouseManager.y;
        if (Turn.yourTurn == true)
        {
            ymax = myy + 6;
            xmax = myx + 6;
            for (int ymin = myy - 6; ymin <= ymax; ymin++)
            {
                for (int xmin = myx - 6; xmin <= xmax; xmin++)
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

            ymin = myy - 3;
            ymax = myy + 3;

            //Turn.turn++;
            if (myy % 2 == 0)
            {
                for (int i=ymin; i <= ymax; i++)
                {
                    if ((i == myy - 3) || (i == myy + 3))
                    {
                        xmin = myx - 2;
                        xmax = myx + 1;
                        for(int j = xmin; j <= xmax; j++)
                        {
                            neighbors = GameObject.Find("Hex_" + j + "_" + i);
                            if (neighbors != null)
                            {
                                minus = neighbors.GetComponentInChildren<MeshRenderer>();
                                minus.material.color = Color.blue;
                            }
                        }
                    }
                    else if ((i == myy - 2) || (i == myy + 2))
                    {
                        xmin = myx - 2;
                        xmax = myx + 2;
                        for (int j = xmin; j <= xmax; j++)
                        {
                            neighbors = GameObject.Find("Hex_" + j + "_" + i);
                            if (neighbors != null)
                            {
                                minus = neighbors.GetComponentInChildren<MeshRenderer>();
                                minus.material.color = Color.blue;
                            }
                        }
                    }
                    else if ((i == myy - 1) || (i == myy + 1))
                    {
                        xmin = myx - 3;
                        xmax = myx + 2;
                        for (int j = xmin; j <= xmax; j++)
                        {
                            neighbors = GameObject.Find("Hex_" + j + "_" + i);
                            if (neighbors != null)
                            {
                                minus = neighbors.GetComponentInChildren<MeshRenderer>();
                                minus.material.color = Color.blue;
                            }
                        }
                    }
                    else if (i == myy)
                    {
                        xmin = myx - 3;
                        xmax = myx + 3;
                        for (int j = xmin; j <= xmax; j++)
                        {
                            neighbors = GameObject.Find("Hex_" + j + "_" + i);
                            if (neighbors != null)
                            {
                                minus = neighbors.GetComponentInChildren<MeshRenderer>();
                                minus.material.color = Color.blue;
                            }
                        }
                    }
                }
            }


            else if (myy % 2 == 1)
            {
                for (int i = ymin; i <= ymax; i++)
                {
                    if ((i == myy - 3) || (i == myy + 3))
                    {
                        xmin = myx - 1;
                        xmax = myx + 2;
                        for (int j = xmin; j <= xmax; j++)
                        {
                            neighbors = GameObject.Find("Hex_" + j + "_" + i);
                            if (neighbors != null)
                            {
                                minus = neighbors.GetComponentInChildren<MeshRenderer>();
                                minus.material.color = Color.blue;
                            }
                        }
                    }
                    else if ((i == myy - 2) || (i == myy + 2))
                    {
                        xmin = myx - 2;
                        xmax = myx + 2;
                        for (int j = xmin; j <= xmax; j++)
                        {
                            neighbors = GameObject.Find("Hex_" + j + "_" + i);
                            if (neighbors != null)
                            {
                                minus = neighbors.GetComponentInChildren<MeshRenderer>();
                                minus.material.color = Color.blue;
                            }
                        }
                    }
                    else if ((i == myy - 1) || (i == myy + 1))
                    {
                        xmin = myx - 2;
                        xmax = myx + 3;
                        for (int j = xmin; j <= xmax; j++)
                        {
                            neighbors = GameObject.Find("Hex_" + j + "_" + i);
                            if (neighbors != null)
                            {
                                minus = neighbors.GetComponentInChildren<MeshRenderer>();
                                minus.material.color = Color.blue;
                            }
                        }
                    }
                    else if (i == myy)
                    {
                        xmin = myx - 3;
                        xmax = myx + 3;
                        for (int j = xmin; j <= xmax; j++)
                        {
                            neighbors = GameObject.Find("Hex_" + j + "_" + i);
                            if (neighbors != null)
                            {
                                minus = neighbors.GetComponentInChildren<MeshRenderer>();
                                minus.material.color = Color.blue;
                            }
                        }
                    }
                }
            }
            Canvas.gameObject.SetActive(false);
           
            
        }
    }

    
}
