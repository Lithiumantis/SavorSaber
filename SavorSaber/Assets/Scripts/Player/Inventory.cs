using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public Stack<DropClass> skewer0;
    public Stack<DropClass> skewer1;
    public Stack<DropClass> skewer2;

    private int currentSkewer = 0;
    private Stack<DropClass>[] quiver = new Stack<DropClass>[3];
// MONOBEHAVIOR FUNCTIONS -------------------------------------------------------------------------

    void Start () {
        quiver[0] = new Stack<DropClass>();
        quiver[1] = new Stack<DropClass>();
        quiver[2] = new Stack<DropClass>();

    }
	
	// Update is called once per frame
	void Update () {

        //healing
        if (Input.GetButtonDown("Heal"))
        {
            Heal(currentSkewer);
        }

	}

    public void AddToSkewer(int num, DropClass dropClass)
    {
        if(num >= 0 && num <= 2)
        {
            quiver[num].Push(dropClass);
            Debug.Log("Added to skewer. Current status: ");
            foreach (DropClass item in quiver[num]) { print(item); }
        }
        else
        {
            Debug.Log("Error: Invalid skewer number");
        }
    }

    private void Heal(int num)
    {
        DropClass topItem;
        PlayerHealth health = GetComponent<PlayerHealth>();

        //do nothing if skewer is empty or hp is full
        if(quiver[num].Count <= 0)
        {
            Debug.Log("Cannot heal with empty skewer");
            return;
        }else if(health.health == health.maxHealth){
            Debug.Log("Health max");
            return;
        }
        //pop each item off the stack and use its value to heal, but don't let the player eat if they're already full      
        
        while(quiver[num].Count > 0 && health.health < health.maxHealth)
        {
                topItem = quiver[num].Pop();
                health.Heal(topItem.healValue);             
        }
        
    }
}
