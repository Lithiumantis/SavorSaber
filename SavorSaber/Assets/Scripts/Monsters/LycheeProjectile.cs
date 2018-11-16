using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LycheeProjectile : MonoBehaviour {
    //How fast it goes
    public float speed;
    //How much wallop it packs
    public int damage;
    //How long it lasts
    public float lifetime;
    public float timer;

	// Use this for initialization
	void Start () {
        Invoke("destroyProjectile", lifetime);
        timer = 0;
	}

    // Update is called once per frame
    void Update()
    {
        //Move the projectile
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        //A variable that helps fix a bug where projectile is automatically deleted when lychee was up against a wall
        timer += Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        //Player and walls are the only things that the projectile can hit
        if(hit.gameObject.tag == "Player")
        {
            //Register hit and damage player
            GameObject Player = hit.gameObject;
            Player.GetComponentInChildren<PlayerHealth>().TakeDamage(damage);
            destroyProjectile();
        }else if (hit.gameObject.tag == "Wall" && timer > 0.5f)
        {
            //The timer helps with projectile not getting auto-destroyed
            destroyProjectile();
            timer = 0;
        }
    }

    //Helper function to destroy projectile. Animations or sound fx can go here too for more feedback.
    void destroyProjectile()
    {
        Destroy(gameObject);
    }
}
