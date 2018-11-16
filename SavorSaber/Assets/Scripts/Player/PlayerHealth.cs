using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int maxHealth = 10;
    public int health;


	// Use this for initialization
	void Start () {
        health = maxHealth;

        //use this to test healing mechanics 
        //health = 5;
	}

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        Debug.Log("Player took " + dmg + " damage!");
        Debug.Log("Player Health: " + health);
        if(health <= 0)
        {
            Die();
        }
    }

    public void ResetHealth()
    {
        health = maxHealth;
    }

    public void Die()
    {
        Debug.Log("Player dead");

        //whatever we want to happen on death. Animations, etc. Respawn? 
    }

    public void Heal(int addedHealth)
    {
        health += addedHealth;
        
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        Debug.Log("healed to " + health);
    }
}
