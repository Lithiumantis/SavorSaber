using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearHit : MonoBehaviour {

    private string type;
    private Inventory inventory;
    private DropSpawn drop;

    private void Start()
    {
        inventory = transform.GetComponentInParent<Inventory>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Drop")
        {
            Debug.Log("spear hit drop");

			AudioPlayer.main.playSFX ("sfx_stab");
            drop = collision.gameObject.GetComponent<DropSpawn>();
            type = drop.type;
            inventory.addToSkewer(0, type);
            collision.gameObject.active = false;
        }
        
    }
}
