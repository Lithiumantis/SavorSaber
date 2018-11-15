﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int maxHealth = 10;
    private int health;


	// Use this for initialization
	void Start () {
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
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

	public int GetHealth(){
		return health;
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
}