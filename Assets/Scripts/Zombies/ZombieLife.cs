﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieLife : MonoBehaviour
{

    public GameObject zombie;
    public float life;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void damage(GameObject collision)
    {
         if(collision.tag == "damagingObject")
        {
            life -= collision.GetComponent<BulletVars>().damage;
            if (life <= 0)
            {
                Destroy(gameObject, 1.0F);
            }
        }
         
    }
}
