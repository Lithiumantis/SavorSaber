using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public Stack<DropClass> skewer0;
    public Stack<DropClass> skewer1;
    public Stack<DropClass> skewer2;


// MONOBEHAVIOR FUNCTIONS -------------------------------------------------------------------------

    void Start () {
        skewer0 = new Stack<DropClass>();
        skewer1 = new Stack<DropClass>();
        skewer2 = new Stack<DropClass>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddToSkewer(int num, DropClass dropClass)
    {
        if(num == 0)
        {
            skewer0.Push(dropClass);
            Debug.Log("Added to skewer. Current status: ");
            foreach (DropClass item in skewer0) { print(item); }
        }
        else if(num == 1)
        {
            skewer1.Push(dropClass);
            Debug.Log("Added to skewer. Current status: ");
            foreach(DropClass item in skewer1) { print(item); }
        }
        else if(num == 2)
        {
            skewer2.Push(dropClass);
            Debug.Log("Added to skewer. Current status: ");
            foreach (DropClass item in skewer2) { print(item); }
        }
        else
        {
            Debug.Log("ERROR: INVALID SKEWER INDEX");
        }

        

    }
}
