using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
    public int currentHealth;
    public int startHealth;
    int damage=20;
    public static bool takeDamage;
    public static bool willBeDestroyed;
    public Slider healthSlider;
    public GameObject enemyObject;
    // Use this for initialization
    void Awake () {
        currentHealth = startHealth;
        healthSlider.value = currentHealth;
        willBeDestroyed = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (currentHealth > 0)
        {
            PlayerHealt.enemyDefeated = false;
            if (takeDamage)
            {
                currentHealth = currentHealth - damage;
                healthSlider.value = currentHealth;
                takeDamage = false;
            }
        }

        else if ((currentHealth <= 20) & (currentHealth >0))
        {
            willBeDestroyed = true;
        }

        else if (currentHealth == 0)
        {
            PlayerHealt.enemyDefeated = true;
            Cash.cash = Cash.cash + 10;
            KillText.killCounter++;
            Turn.turn = 0;
            Destroy(enemyObject);
        }
	}
}
