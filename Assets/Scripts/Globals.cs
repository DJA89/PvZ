﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals {
    // Singleton
    private Globals() { }
    public static Globals Instance { get; } = new Globals();

    // get and change selected object
    public GameObject SelectedObject { get; set; }

    // get and change sun score
    private int _sunScore = 0;
    public static readonly int MAX_SCORE = 999;
    public int SunScore
    {
        get {
            return _sunScore;
        }
        set {
            _sunScore = Mathf.Min(value, MAX_SCORE);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
