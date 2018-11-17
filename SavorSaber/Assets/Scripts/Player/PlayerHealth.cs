using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int maxHealth = 10;
    public int health;

    public Slider slider;


	// Use this for initialization
	void Start () {
        health = maxHealth;

        //use this to test healing mechanics 
        health = 5;
        UpdateUI();

    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        UpdateUI();

        AudioPlayer.main.playSFX("sfx_damage");

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

        //whatever we want to happen on death. Animations, etc. Respawn? 
    }

    public void Heal(int addedHealth)
    {
        health += addedHealth;
        UpdateUI();

        AudioPlayer.main.playSFX("sfx_heal");

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        Debug.Log("healed to " + health);
    }

    private void UpdateUI()
    {
        slider.value = maxHealth - health;
    }
}
