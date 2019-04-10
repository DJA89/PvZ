﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject shot;
    public GameObject shotSpawn;
    float timeToShoot;
    //public AudioClip sound;

    // Use this for initialization
    void Start()
    {

        timeToShoot = 0.5f;

    }

    // Update is called once per frame
    void Update()
    {

        timeToShoot -= Time.deltaTime;
        if (timeToShoot <= 0.0f)
        {
            timeToShoot = 0.5f;
            GameObject obj = (GameObject)Instantiate(shot, shotSpawn.transform.position, transform.rotation);
            Vector3 toLeftBorder = new Vector3(0.0f, 0.0f, obj.GetComponent<Collider>().bounds.size.z);
            obj.transform.Translate(toLeftBorder);
            obj.transform.parent = transform; // add as child to current
            obj.GetComponent<Rigidbody>().AddForce(1000.0f, 0.0f, 0.0f);
            //AudioSource.PlayClipAtPoint(sound, transform.position);
        }

    }
}
