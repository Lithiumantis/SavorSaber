using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {

	public PlayerHealth player_hp;
	public Attack player_pow;
	public RectTransform hp_cover;
	public RectTransform pow_cover;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		hp_cover.sizeDelta = new Vector2 (hp_cover.sizeDelta.x, 
			(player_hp.maxHealth - player_hp.GetHealth ()) / player_hp.maxHealth);
		pow_cover.sizeDelta = new Vector2 (pow_cover.sizeDelta.x, 
			(player_pow.spearMaxDist - player_pow.GetSpearPower()) / player_pow.spearMaxDist);
	}
}
