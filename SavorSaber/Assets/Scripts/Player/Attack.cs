using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script to be attached to the weapon rig. Gets input for attacks, applies visuals, etc. 
//will need to be significantly altered when animated sprites are in, but for now it mostly moves a bunch of non-animated sprites around. 

public class Attack : MonoBehaviour {

    public GameObject knife;
    public GameObject spear;
    public GameObject slashVisual;
    public GameObject player;

    public float rotateSpeed = 1400f;
    public float stabDistance = 4f;
    public float stabSpeed = 10f;
    public float spearMaxDist = 16f;

    private SpriteRenderer knifeRenderer;
    private SpriteRenderer slashRenderer;
    private SpriteRenderer spearRenderer;

    private CircleCollider2D slashCollider;
    private CapsuleCollider2D spearCollider;

    private TargetController targetController;

    private Monster_Kill monsterkill;

    private float leftMouseInputValue;
    private float rightMouseInputValue;

    //animation controllers
    Animator otheranim;
    private bool slashing = false;
    private bool stabbing = false;
    private bool endSignalSent = false;

    //spear private variables
    private Vector3 spearStart; //has to be global right now for stab to work properly, otherwise they get reset every update loop
    private float spearPower;
	private float spearLevel = 0;
    private bool longThrow = false; //whether RMB skewers or throws
    public bool throwevent = false; 
    public bool lungeevent = false;

// MONOBEHAVIOR FUNCTIONS -------------------------------------------------------------------------

    void Start ()
    {
        //get sprite components and target controller script
        knifeRenderer = knife.GetComponent<SpriteRenderer>();
        spearRenderer = spear.GetComponent<SpriteRenderer>();
        slashRenderer = slashVisual.GetComponent<SpriteRenderer>();
        targetController = GetComponent<TargetController>();
        slashCollider = GetComponent<CircleCollider2D>();
        spearCollider = spear.GetComponent<CapsuleCollider2D>();
        spearRenderer.enabled = false;
    }

    void Awake() {
            otheranim = player.GetComponent<Animator>();
    }
	
	void Update ()
    {
        StartCoroutine(slash());
        stab();
    }

// MOVE SPRITES WHEN ATTACKING -------------------------------------------------------------------------

    void stab()
    {
        Vector3 thrust = new Vector3(0, stabSpeed, 0);
        
        //increase throw power while fire2 is held down
        if(Input.GetButton("Fire2") && !slashing && !stabbing)
        {
            //increase power
            spearPower+= 0.2f;
            //print(spearPower);

            if(spearPower > spearMaxDist)
            {
                spearPower = spearMaxDist;
				if (spearLevel <= 2) {
					AudioPlayer.main.playSFX ("sfx_charge_3");
					spearLevel = 3;
				}
            }
			else if (spearPower >= (spearMaxDist / 3) * 2) {
				if (spearLevel <= 1) {
					AudioPlayer.main.playSFX ("sfx_charge_2");
					spearLevel = 2;
				}
			}
			else if (spearPower >= (spearMaxDist / 3)) {
				if (spearLevel <= 0) {
					AudioPlayer.main.playSFX ("sfx_charge_1");
					spearLevel = 1;
				}
			}
        }

        //either stab or throw on release
        if(Input.GetButtonUp("Fire2") && !slashing && !stabbing)
        {
            if (spearPower > stabDistance) { longThrow = true; otheranim.SetBool("Throwing", true); }
            else                { longThrow = false; otheranim.SetBool("Lunging", true); }

            //print("right click");
            stabbing = true;

            //get the starting position of spear when beginning a new stab action
            spearStart = spear.transform.localPosition;
			AudioPlayer.main.playSFX("sfx_throw");
			spearLevel = 0;
        }

        //short stab
        if (stabbing && !longThrow)
        {
            if(lungeevent == true){
                spear.transform.Translate(thrust * Time.deltaTime);

                //enable collision trigger
                spearCollider.enabled = true;

                //stop stab if gone far enough
                if(spear.transform.localPosition.y > spearStart.y + stabDistance)
                {
                    stabbing = false;
                    spear.transform.localPosition = spearStart;

                    //reset spear power
                    spearPower = 0;

                    //disable trigger
                    spearCollider.enabled = false;
                    otheranim.SetBool("Lunging", false);
                }
            }
        }
        //long throw
        else if(stabbing && longThrow)
        {
            if(throwevent == true){
                spearRenderer.enabled = true;
                spear.transform.Translate(thrust * Time.deltaTime);

                //stop stab if gone far enough
                if (spear.transform.localPosition.y > spearStart.y + spearPower)
                {
                    stabbing = false;
                    spear.transform.localPosition = spearStart;
                    spearRenderer.enabled = false;

                    //reset spear power
                    spearPower = 0;
                    otheranim.SetBool("Throwing", false);
                }
            }
        }

    }

    // coroutines for making a slashing "animation" start and stop when left clicking
    IEnumerator slash()
    {
        //set slashing flag
        if (Input.GetButtonDown("Fire1") && !slashing && !stabbing)
        {
            //print("left click");
            slashing = true;
            targetController.slashing = true;
            otheranim.SetBool("Attacking", true);
			AudioPlayer.main.playSFX("sfx_slash");
        }

        //actually do stuff while slashing flag is set
        if (slashing)
        {
            print("slashing");
            // anim.SetBool("Attacking", true);
            knifeRenderer.enabled = false;
            spearRenderer.enabled = false;
            //slashRenderer.enabled = true;
            slashCollider.enabled = true;

            slashVisual.transform.RotateAround(slashVisual.transform.position, -1 * slashVisual.transform.forward, Time.deltaTime * rotateSpeed);

            //start the termination corouting if not already started
            if (!endSignalSent)
            {
                StartCoroutine(executeAfterSeconds(0.35f));
            }
            

        }
        yield return null;
    }

    //sub-routine for delay when slashing
    IEnumerator executeAfterSeconds(float time)
    {
        endSignalSent = true;

        yield return new WaitForSeconds(time);
        
        slashing = false;
        targetController.slashing = false;

        //knifeRenderer.enabled = true;
        // spearRenderer.enabled = true;
        //slashRenderer.enabled = false;
        slashCollider.enabled = false;
        otheranim.SetBool("Attacking", false);
        print("slashing end");

        endSignalSent = false;

        yield return null;
    }

    // FUNCTIONS TO ACTUALLY INTERACT WITH ENEMIES

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("touching");

        if (collision.gameObject.tag == "Monster")
        {
            //Debug.Log("MONSTER SLASHED");
            monsterkill = collision.gameObject.GetComponent<Monster_Kill>();
            monsterkill.KillMonster();
			AudioPlayer.main.playSFX ("sfx_damage");
            collision.gameObject.active = false;
        }
    }
}
