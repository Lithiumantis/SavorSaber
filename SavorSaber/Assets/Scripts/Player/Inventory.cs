using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public Stack<GameObject> skewer1;
    public Stack<GameObject> skewer2;
    public Stack<GameObject> skewer3;

    // Use this for initialization
    void Start () {
        skewer1 = new Stack<GameObject>();
        skewer2 = new Stack<GameObject>();
        skewer3 = new Stack<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
