using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public static bool isDead;

    public int maxHealth = 10;
    public int health;

    public Slider slider;


	// Use this for initialization
	void Start () {
        health = maxHealth;
        isDead = false;
        //use this to test healing mechanics 
        health = 5;
        UpdateUI();

    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        UpdateUI();

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
        UpdateUI();
    }

    public void Die()
    {
        Debug.Log("Player dead");
        isDead = true;

        //whatever we want to happen on death. Animations, etc. Respawn? 
    }

    public void Heal(int addedHealth)
    {
        health += addedHealth;
        UpdateUI();


        if (health > maxHealth)
        {
            health = maxHealth;
        }

        Debug.Log("healed to " + health);
    }

    private void UpdateUI()
    {
        slider.value = health;
    }
}
