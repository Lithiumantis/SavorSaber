﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    //public variables
    public float speed = 0.5f;

    //private variables
    private float xInputValue;
    private float yInputValue;
    private Rigidbody2D rigidbody;

// MONOBEHAVIOR FUNCTIONS -------------------------------------------------------------------------

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

	void Update ()
    {
        //get horiz and vert input
        xInputValue = Input.GetAxisRaw("Horizontal");
        yInputValue = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        //create new vector from input, move sprite along that vector
        Vector2 movement = new Vector2(xInputValue * speed, yInputValue * speed);
        rigidbody.MovePosition(rigidbody.position + movement);
    }
}
