﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class day_night : MonoBehaviour
{
    public Color nightLightColor;

    // Start is called before the first frame update
    void Start()
    {
        TextAsset levelFile = Globals.Instance.currentLevelFile;
        string[] lines = levelFile.ToString().Split(new string[] { "\n", "\r\n" }, StringSplitOptions.None);
        if (lines[0] == "1") //it's night
        {
            Light lt = GetComponent<Light>();
            lt.color = nightLightColor;
            lt.intensity = 0.6f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
