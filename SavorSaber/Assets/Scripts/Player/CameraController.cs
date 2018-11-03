using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {  
    public GameObject player;
    public float rotateSpeed = 30f;
    private Vector3 offset;
    private Quaternion rot1;
    private Quaternion rot2;


	void Start () {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
