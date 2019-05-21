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

    public void Update()
    {
        int aux = gameObject.GetComponent<ZombieVars>().state;
        float current_speed = speed;
        if (gameObject.GetComponent<ZombieVars>().state == 1) //frozen
        {
            if (Time.frameCount <= gameObject.GetComponent<ZombieVars>().frozen_frame + 300)
            {
                current_speed = current_speed / 2;
            }
            else
            {
                GetComponent<Renderer>().material.color = Color.white;
                gameObject.GetComponent<ZombieVars>().state = 0;
            }
        }
        transform.Translate(Vector3.back * Time.deltaTime * current_speed);
        //gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-speed, 0, 0);
    }
}
