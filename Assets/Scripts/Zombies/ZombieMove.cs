using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour
{

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-speed, 0, 0);
        //gameObject.GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(-speed * Time.deltaTime, 0, 0), transform.position);
    }
}
