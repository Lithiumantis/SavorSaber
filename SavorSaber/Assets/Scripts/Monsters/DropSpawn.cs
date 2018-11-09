using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawn : MonoBehaviour {

    public float maxDrift = 4;
    public float driftSpeed = 1;
    private Vector3 target;

	// Use this for initialization
	void Start () {

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float x = transform.position.x + Random.Range(-maxDrift, maxDrift);
        float y = transform.position.y + Random.Range(-maxDrift, maxDrift);
        float z = transform.position.z + Random.Range(-maxDrift, maxDrift);

        target = new Vector3(x, y, z);

    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, target, driftSpeed * Time.deltaTime);
	}
}
