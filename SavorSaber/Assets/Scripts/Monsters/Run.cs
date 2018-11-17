using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour {

	public Transform Player;
	public float moveSpeed = 3;
	public float minDist = 5;
	private float range;

	// Update is called once per frame
	void FixedUpdate () {
		range = Vector2.Distance (transform.position, Player.position);

		if(range < minDist){ 
			transform.position = Vector2.MoveTowards (transform.position, Player.transform.position, (-1) * moveSpeed * Time.deltaTime);
		}

	}
}
