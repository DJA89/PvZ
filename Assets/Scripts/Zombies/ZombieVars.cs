﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ZombieVars : MonoBehaviour
{
    public float damage;
    public int state; //0 normal, 1 frozen
    public int frozen_frame;
    private void Start()
    {
        frozen_frame = -301;
        state = 0;
    }
}
