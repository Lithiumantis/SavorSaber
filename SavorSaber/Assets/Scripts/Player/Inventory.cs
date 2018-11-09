using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public Stack<string> skewer0;
    public Stack<string> skewer1;
    public Stack<string> skewer2;


// MONOBEHAVIOR FUNCTIONS -------------------------------------------------------------------------

    void Start () {
        skewer0 = new Stack<string>();
        skewer1 = new Stack<string>();
        skewer2 = new Stack<string>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addToSkewer(int num, string str)
    {
        if(num == 0)
        {
            skewer0.Push(str);
            Debug.Log("Added to skewer. Current status: ");
            foreach (string item in skewer0) { print(item); }
        }
        else if(num == 1)
        {
            skewer1.Push(str);
            Debug.Log("Added to skewer. Current status: ");
            foreach(string item in skewer1) { print(item); }
        }
        else if(num == 2)
        {
            skewer2.Push(str);
            Debug.Log("Added to skewer. Current status: ");
            foreach (string item in skewer2) { print(item); }
        }
        else
        {
            Debug.Log("ERROR: INVALID SKEWER INDEX");
        }

        

    }
}
