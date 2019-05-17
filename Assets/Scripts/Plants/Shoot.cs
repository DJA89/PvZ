using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject shot;
    public GameObject shotSpawn;
    public AudioClip sound;
    float RELATIVE_SFX_VOLUME = 0.5f;
    const float SHOOTING_PERIOD = 1.5f; // seconds
    float timeToShoot= SHOOTING_PERIOD;
    //public AudioClip sound;
    private GameObject zombieSpawner;

    // Use this for initialization
    void Start()
    {
        zombieSpawner = GameObject.Find("ZombieSpawner");
    }

    // Update is called once per frame
    void Update()
    {

        timeToShoot -= Time.deltaTime;
        if (timeToShoot <= 0.0f && zombieSpawner.GetComponent<Spawner>().lanes[gameObject.GetComponent<PlantVars>().lane].transform.childCount != 0)
        {
            timeToShoot = SHOOTING_PERIOD;
            // as the shots are spawned as CHILDREN of the Plant, they automatically inherit the plant.transform
            GameObject obj = (GameObject)Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation); // just apply spawnPoint transform 
            // move by half x size (move out of plant to the front)
            Vector3 toLeftBorder = new Vector3(obj.GetComponent<Collider>().bounds.size.x/2, 0.0f, 0.0f);
            obj.transform.Translate(toLeftBorder);
            obj.transform.parent = transform; // add as child to current
            obj.GetComponent<Rigidbody>().AddForce(1000.0f, 0.0f, 0.0f); // shoot
            AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position, Globals.Instance.sfxVolume * RELATIVE_SFX_VOLUME); // play sound
            gameObject.GetComponent<Animator>().SetTrigger("shoot"); // shooting animation
        }

    }
}
