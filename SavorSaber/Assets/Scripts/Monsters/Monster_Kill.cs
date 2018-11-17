using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Kill : MonoBehaviour {

    public string type = "Default";
    public GameObject drop;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void KillMonster()
    {
        //Debug.Log("Monster Killed");
        AudioPlayer.main.playSFX("vo_fruit_rip");
        GameObject dropA = Instantiate(drop, this.transform.position, Quaternion.identity);
        GameObject dropB = Instantiate(drop, this.transform.position, Quaternion.identity);
    }
}
