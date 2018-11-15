using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawn : MonoBehaviour {

    //movement values
    public float maxDrift = 4;
    public float driftSpeed = 1;

    //drop-specific data
    //set on a per-prefab basis in the Inspector
    public string type = "Default";
    public Texture2D sprite = null;

    public DropClass dropClass;

    private Vector3 target;

	// Use this for initialization
	void Start () {

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float x = transform.position.x + Random.Range(-maxDrift, maxDrift);
        float y = transform.position.y + Random.Range(-maxDrift, maxDrift);
        float z = transform.position.z + Random.Range(-maxDrift, maxDrift);

        target = new Vector3(x, y, z);

        //pack all relevant data into a class so it can be added to the player's inventory stack as a single object
        dropClass.type = type;
        dropClass.sprite = sprite;

    }
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, target, driftSpeed * Time.deltaTime);
	}
}
