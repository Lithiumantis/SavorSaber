using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {

    //Quaternion for 
    private Quaternion mouseRotation;
    private Quaternion startRotation;

	// Use this for initialization
	void Start () {
        startRotation = transform.rotation;

    }
	
	// Update is called once per frame
	void Update () {

        //get the angle between the mouse cursor and player, extract z rotation by translating to Euler
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseRotation = Quaternion.LookRotation(Vector3.forward, mousepos - transform.position);
        Vector3 eulerMouseRotation = mouseRotation.eulerAngles;
        float eulerMouseZ = eulerMouseRotation.z;

        //apply z rotation of mouse angle to circle's z rotation by translating back from Euler
        Vector3 eulerCircleRotation = transform.rotation.eulerAngles;
        eulerCircleRotation.z = eulerMouseZ;
        Quaternion newRotation = Quaternion.Euler(eulerCircleRotation);
        transform.rotation = newRotation;


    }
}
