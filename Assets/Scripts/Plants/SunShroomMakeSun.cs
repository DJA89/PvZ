using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunShroomMakeSun : MonoBehaviour
{
    public GameObject sun;
    public float velocity;
    private float lastSpawnTime;
    private float spawnPeriod;
    const float INITIAL_SPAWN_PERIOD = 7; // seconds
    const float NORMAL_SPAWN_PERIOD = 20; // seconds
    const float ANIMATION_OFFSET = 2; // seconds
    private bool animationStarted = false;
    private float plantedTime;

    // Start is called before the first frame update
    void Start()
    {
        lastSpawnTime = Time.time;
        spawnPeriod = INITIAL_SPAWN_PERIOD;
        plantedTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!animationStarted && Time.time - lastSpawnTime > spawnPeriod - ANIMATION_OFFSET)
        {
            gameObject.GetComponent<Animator>().SetTrigger("popSun");
            animationStarted = true;
        }
        if (Time.time - lastSpawnTime > spawnPeriod)
        {
            GameObject newSun = (GameObject)Instantiate(sun, transform.position, transform.rotation, transform.parent);
            int sunAmount;
            if (plantedTime + 120 > Time.time)
            {
                sunAmount = 15;
            }
            else
            {
                sunAmount = 25;
            }
            newSun.GetComponent<SunVars>().sunAmount = sunAmount;
            float xForce = Random.Range(-100, 100);
            float zForce = Random.Range(-100, 100);
            newSun.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(xForce, velocity, zForce));
            lastSpawnTime = Time.time;
            spawnPeriod = NORMAL_SPAWN_PERIOD;
            animationStarted = false;
        }
    }
}
