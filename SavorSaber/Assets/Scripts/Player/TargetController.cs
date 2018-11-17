using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//script that handles the rotation of the player's weapon rid
//this will be obsolete once animated sprites are added. 

public class TargetController : MonoBehaviour {

    //Quaternion for storing mouse
    private Quaternion mouseRotation;

    //lets the rotation be applied to other game objects
    public GameObject child;

    //do not change slashing visual rotation when slashing
    public bool slashing;

    void Start () {
        slashing = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (!slashing)
        {
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

            child.transform.rotation = newRotation;
        }

    }
}
