using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //hide cursor during play
        //Cursor.visible = false;
		AudioPlayer.main.playBGM("stage1", 0.25F);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
