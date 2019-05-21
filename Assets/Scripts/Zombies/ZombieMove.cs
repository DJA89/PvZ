using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour
{

    public float speed;
    private int frames_since_frozen;
    // Start is called before the first frame update
    void Start()
    {
        frames_since_frozen = 0;
    }

    public void freeze()
    {
        float current_speed = speed;
        if (gameObject.GetComponent<ZombieVars>().state == 1) //frozen
        {
            if (Time.frameCount <= gameObject.GetComponent<ZombieVars>().frozen_frame + 300)
            {
                current_speed = current_speed / 2;
            }
            else
            {
                gameObject.GetComponent<ZombieVars>().state = 0;
            }
        }
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-speed, 0, 0);
    }
}
