using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    //public variables
    public float speed = 0.5f;

    //private variables
    private float xInputValue;
    private float yInputValue;
    private Rigidbody2D rigidbody;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start ()
    {

	}
	

	void Update ()
    {
        xInputValue = Input.GetAxis("Horizontal");
        yInputValue = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 movement = new Vector2(xInputValue * speed, yInputValue * speed);
        rigidbody.MovePosition(rigidbody.position + movement);
    }
}
