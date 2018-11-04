using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public GameObject knife;
    public GameObject spear;
    public GameObject slashVisual;

    public float rotateSpeed = 1400f;

    private SpriteRenderer knifeRenderer;
    private SpriteRenderer slashRenderer;
    private SpriteRenderer spearRenderer;

    private float leftMouseInputValue;
    private float rightMouseInputValue;

    private TargetController targetController;

    private bool slashing = false;

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
    }

    IEnumerator slash()
    {
        //print("Starting coroutine");
        if (Input.GetButtonDown("Fire1") && !slashing)
        {
            print("left click");
            slashing = true;
            targetController.slashing = true;
        }

        if (slashing)
        {
            knifeRenderer.enabled = false;
            spearRenderer.enabled = false;
            slashRenderer.enabled = true;

            slashVisual.transform.RotateAround(slashVisual.transform.position, -1 * slashVisual.transform.forward, Time.deltaTime * rotateSpeed);

            StartCoroutine(executeAfterSeconds(0.35f));

        }
        else


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
