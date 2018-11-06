using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public GameObject knife;
    public GameObject spear;
    public GameObject slashVisual;

    public float rotateSpeed = 1400f;
    public float stabDistance = 4f;
    public float stabSpeed = 10f;
    public float spearMaxDist = 16f;

    private SpriteRenderer knifeRenderer;
    private SpriteRenderer slashRenderer;
    private SpriteRenderer spearRenderer;

    private float leftMouseInputValue;
    private float rightMouseInputValue;

    private TargetController targetController;

    private bool slashing = false;
    private bool stabbing = false;

    private Vector3 spearStart; //has to be global right now for stab to work properly, otherwise they get reset every update loop
    private float spearPower;
    private bool longThrow = false; //whether RMB skewers or throws

	void Start ()
    {
        //get sprite components and target controller script
        knifeRenderer = knife.GetComponent<SpriteRenderer>();
        spearRenderer = spear.GetComponent<SpriteRenderer>();
        slashRenderer = slashVisual.GetComponent<SpriteRenderer>();
        targetController = GetComponent<TargetController>();
    }
	

	void Update ()
    {
        StartCoroutine(slash());
        stab();
    }

    void stab()
    {
        
        Vector3 thrust = new Vector3(0, stabSpeed, 0);

        //increase throw power while fire2 is held down
        if(Input.GetButton("Fire2") && !slashing && !stabbing)
        {
            //increase power
            spearPower+= 0.2f;
            print(spearPower);

            if(spearPower > spearMaxDist)
            {
                spearPower = spearMaxDist;
            }
        }

        //either stab or throw on release
        if(Input.GetButtonUp("Fire2") && !slashing && !stabbing)
        {
            if (spearPower > stabDistance) { longThrow = true; }
            else                { longThrow = false; }

            print("right click");
            stabbing = true;

            //get the starting position of spear when beginning a new stab action
            spearStart = spear.transform.localPosition;
        }

        //short stab
        if (stabbing && !longThrow)
        {
            spear.transform.Translate(thrust * Time.deltaTime);

            //stop stab if gone far enough
            if(spear.transform.localPosition.y > spearStart.y + stabDistance)
            {
                stabbing = false;
                spear.transform.localPosition = spearStart;

                //reset spear power
                spearPower = 0;
            }
        }
        else if(stabbing && longThrow)
        {
            spear.transform.Translate(thrust * Time.deltaTime);

            //stop stab if gone far enough
            if (spear.transform.localPosition.y > spearStart.y + spearPower)
            {
                stabbing = false;
                spear.transform.localPosition = spearStart;

                //reset spear power
                spearPower = 0;
            }
        }

    }


    // coroutines for making a slashing "animation" start and stop when left clicking
    IEnumerator slash()
    {
        //set slashing flag
        if (Input.GetButtonDown("Fire1") && !slashing && !stabbing)
        {
            print("left click");
            slashing = true;
            targetController.slashing = true;
        }

        //actually do stuff while slashing flag is set
        if (slashing)
        {
            knifeRenderer.enabled = false;
            spearRenderer.enabled = false;
            slashRenderer.enabled = true;

            slashVisual.transform.RotateAround(slashVisual.transform.position, -1 * slashVisual.transform.forward, Time.deltaTime * rotateSpeed);

            StartCoroutine(executeAfterSeconds(0.35f));

        }
        yield return null;
    }

    IEnumerator executeAfterSeconds(float time)
    {
        yield return new WaitForSeconds(time);

        slashing = false;
        targetController.slashing = false;

        knifeRenderer.enabled = true;
        spearRenderer.enabled = true;
        slashRenderer.enabled = false;

        yield return null;
    }

}
