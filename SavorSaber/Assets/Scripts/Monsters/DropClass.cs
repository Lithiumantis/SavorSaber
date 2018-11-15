﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DropClass{

    public string type = "Default";
    public Texture2D sprite = null;

    override public string ToString()
    {
        return type;
    }
}
