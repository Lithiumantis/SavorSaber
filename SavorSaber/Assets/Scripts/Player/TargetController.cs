using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {

    //Quaternion for 
    private Quaternion tempRotation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //test code to make the target rotator move in perspective (i.e., in 3D space)
        //tempRotation = Quaternion.LookRotation(Vector3.forward, mousepos - transform.position);
        //transform.localRotation = new Quaternion(transform.rotation.x, tempRotation.z, transform.rotation.z, transform.rotation.w);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousepos - transform.position);
    }
}
