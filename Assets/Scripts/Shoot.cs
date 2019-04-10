using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject shot;
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
            GameObject obj = (GameObject)Instantiate(shot, transform.position + new Vector3(-1.5f, 5.6f, 0.0f), transform.rotation);
            obj.transform.parent = transform;
            //obj.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-10.0f, 0.0f, 0.0f);
            obj.GetComponent<Rigidbody>().AddForce(-1000.0f, 0.0f, 0.0f);
            //AudioSource.PlayClipAtPoint(sound, transform.position);
        }

    }
}
