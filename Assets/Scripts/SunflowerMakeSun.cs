using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerMakeSun : MonoBehaviour
{
    private int framesPerSun;
    public GameObject sun;
    public float velocity;
    private int currentFrame;

    // Start is called before the first frame update
    void Start()
    {
        currentFrame = 0;
        framesPerSun = 420;
    }

    // Update is called once per frame
    void Update()
    {
        currentFrame++;
        if (currentFrame > framesPerSun)
        {
            GameObject newSun = (GameObject)Instantiate(sun, transform.position, transform.rotation, transform);
            float xForce = Random.Range(-100, 100);
            float zForce = Random.Range(-100, 100);
            newSun.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(xForce, velocity, zForce));
            currentFrame = 0;
            framesPerSun = 1440;
        }
    }
}
