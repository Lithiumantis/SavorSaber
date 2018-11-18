using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public static float timeLeft;
    Text text;
    
    void Awake()
    {
        text = GetComponent<Text>();
        timeLeft = 30.0f;
    }

    
    void Update ()
    {
       

        if (timeLeft < 0)
        {
            text.text = "{{ O_O }}";

        }
        else
        {
            timeLeft -= Time.deltaTime;
            text.text = Math.Round(timeLeft, 2).ToString();
        }
	}
}
