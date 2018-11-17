using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DropClass{

    public string type = "Default";
    public Sprite sprite = null;
    public int healValue = 1;

    override public string ToString()
    {
        return type;
    }
}
