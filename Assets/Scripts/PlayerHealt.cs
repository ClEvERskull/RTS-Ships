using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealt : MonoBehaviour {
    public static bool damaged;
    public int startHealth = 100;
    public int current;
    public int damage;
    public Slider healthSlider;
    public Image damageImg;
    public float damageSpeed = 2.0f;
    public Color damageColor = new Color(1f, 0f, 0f, 0.1f);
    //public Color deadColor = new Color(1f, 0f, 0f, 1f);
    public GameObject player;
    public Canvas Canvas;
    public static bool enemyDefeated;
    public Canvas deathCanvas;
    Enemy enemyObj;
    void Awake () {
        current = startHealth;
        player = GameObject.Find("Player/player");
        deathCanvas.gameObject.SetActive(false);
    }
	
	void Update () {
        damage = Enemy.difference + 10;
        if (current > 0)
        {
            if (damaged)
            {
                damageImg.color = damageColor;
                current = current - damage;
                healthSlider.value = current;
                damaged = false;
                
            }
            else
            {
                damageImg.color = Color.Lerp(damageImg.color, Color.clear, damageSpeed * Time.deltaTime);
            }

            if (enemyDefeated != false)
            {
                current = startHealth;
                healthSlider.value = current;
            }
        }
        else if (current <= 0)
        {
            death();
        }
    }

    void death()
    {
        Canvas.gameObject.SetActive(false);
        deathCanvas.gameObject.SetActive(true);
    }
}
