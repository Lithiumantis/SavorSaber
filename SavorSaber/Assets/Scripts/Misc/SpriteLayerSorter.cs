using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLayerSorter : MonoBehaviour {

	SpriteRenderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		rend.sortingOrder = Mathf.RoundToInt (transform.position.y * 100f) * -1;
	}
}
