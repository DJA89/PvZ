using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieShoot : MonoBehaviour
{
    public GameObject shot;
    public AudioClip sound;
    float RELATIVE_SFX_VOLUME = 0.5f;
    const float SHOOTING_PERIOD = 1.5f; // seconds
    float timeToShoot = SHOOTING_PERIOD;
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
        if (timeToShoot <= 0.0f)
        {
            timeToShoot = SHOOTING_PERIOD;
            // as the shots are spawned as CHILDREN of the Plant, they automatically inherit the plant.transform
            GameObject obj = (GameObject) Instantiate(shot, transform.position, transform.rotation); // just apply spawnPoint transform 
            obj.transform.Translate(new Vector3(0.5f, 0.9f, 0));
            AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position, Globals.Instance.sfxVolume * RELATIVE_SFX_VOLUME); // play sound
            //gameObject.GetComponent<Animator>().SetTrigger("shoot"); // shooting animation
        }

    }
}
