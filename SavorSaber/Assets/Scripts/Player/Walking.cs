using UnityEngine;
using System.Collections;
public class Walking : MonoBehaviour {
    private Animator anim;

    public Vector3 startPosition;
    public Texture2D GUIKey;
    public ArrayList keys = new ArrayList();
    public Vector2 speed = new Vector2(1, 0);

    // initialize
    void Start() {
        startPosition = transform.position;
        GUIKey = Resources.Load("key") as Texture2D;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(
            speed.x * inputX,
            speed.y * inputY,
            0);

        movement *= Time.deltaTime;
        transform.Translate(movement);
    }

    void FixedUpdate() {
        float lastInputX = Input.GetAxis("Horizontal");
        float lastInputY = Input.GetAxis("Vertical");

        if(lastInputX != 0 || lastInputY != 0){
            anim.SetBool("walking", true);
        }else{
            anim.SetBool("walking", false);
        }
    }
}