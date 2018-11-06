using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour {

	public Transform Player;
	public int moveSpeed = 3;
	public int minDist = 5;
	private float range;

	// Update is called once per frame
	void Update () {
		range = Vector2.Distance (transform.position, Player.position);

		if(range < minDist){ 
			transform.position = Vector2.MoveTowards (transform.position, Player.transform.position, (-1) * moveSpeed * Time.deltaTime);
		}

	}
}
