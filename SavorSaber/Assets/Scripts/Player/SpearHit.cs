using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearHit : MonoBehaviour {

    private string type;
    private Texture2D sprite;
    private Inventory inventory;
    private DropSpawn drop;
    private DropClass dropClass;

    private void Start()
    {
        inventory = transform.GetComponentInParent<Inventory>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Drop")
        {
            if (!inventory.CurrentSkewerFull())
            {
                //Debug.Log("spear hit drop");

                AudioPlayer.main.playSFX("sfx_stab");

                drop = collision.gameObject.GetComponent<DropSpawn>();
                dropClass = drop.dropClass;

                inventory.AddToSkewer(0, dropClass);
                collision.gameObject.active = false;
            }
            
        }
        
    }
}
