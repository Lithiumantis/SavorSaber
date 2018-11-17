using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    //public variables
    public float speed = 0.5f;

    //private variables
    private float xInputValue;
    private float yInputValue;
    private Vector2 initialPosition;
    private Rigidbody2D rigidbody;
    private Animator anim;

// MONOBEHAVIOR FUNCTIONS -------------------------------------------------------------------------

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        initialPosition = rigidbody.position;

    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

	void Update ()
    {
        //get horiz and vert input
        xInputValue = Input.GetAxisRaw("Horizontal");
        yInputValue = Input.GetAxisRaw("Vertical");
        anim.SetFloat("SpeedX", xInputValue);
        anim.SetFloat("SpeedY", yInputValue);
        Debug.Log("Hi" + Timer.timeLeft);
        

    }

    private void FixedUpdate()
    {
        if (Timer.timeLeft < 0.2)
        {
            TransformBack();
        }else if (Timer.timeLeft > 0.5)
        {
            Move();
        }
            
            

       
        
        float xLastInput = Input.GetAxisRaw("Horizontal");
        float yLastInput = Input.GetAxisRaw("Vertical");
        if(xLastInput != 0 || yLastInput != 0){
            anim.SetBool("Walking", true);
            if(xLastInput > 0){
                anim.SetFloat("LastMoveX", 1f);
            }else if(xLastInput < 0){
                anim.SetFloat("LastMoveX", -1f);
            }else{
                anim.SetFloat("LastMoveX", 0f);
            }

            if(yLastInput > 0){
                anim.SetFloat("LastMoveY", 1f);
            }else if(yLastInput < 0){
                anim.SetFloat("LastMoveY", -1f);
            }else{
                anim.SetFloat("LastMoveY", 0f);
            }
        }else{
            anim.SetBool("Walking", false);
        }
    }

    private void Move()
    {
        //create new vector from input, move sprite along that vector
        Vector2 movement = new Vector2(xInputValue * speed, yInputValue * speed);
        rigidbody.MovePosition(rigidbody.position + movement);

        // I'm sorry for my temp hacky code -- Tina
        // this is just so soma doesn't move while attacking, bc then the animation looks weird
        if(anim.GetBool("Walking") && !anim.GetBool("Attacking") && !anim.GetBool("Lunging") && !anim.GetBool("Throwing")){
             //create new vector from input, move sprite along that vector
            Vector2 movement = new Vector2(xInputValue * speed, yInputValue * speed);
            rigidbody.MovePosition(rigidbody.position + movement);
        }
       
    }

    private void TransformBack()
    {
        rigidbody.MovePosition(initialPosition);
    }

}
