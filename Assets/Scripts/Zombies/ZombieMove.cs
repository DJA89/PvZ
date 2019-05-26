using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour
{

    public float speed;
    public bool isPeashooterZombie = false;
    public AudioClip[] chomps;
    float RELATIVE_SFX_VOLUME = 0.1f;
    private float startChompingSound;

    // Start is called before the first frame update
    void Start()
    {
        startChompingSound = Time.time;
        if (isPeashooterZombie)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
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
        transform.position += (Vector3.left * Time.deltaTime * current_speed);
    }

    private void OnCollisionStay(Collision collision)
    {
        GameObject plant = collision.gameObject;
        if (collision.gameObject.tag == "Plant")
        {
            // damage plant
            collision.gameObject.GetComponent<PlantLife>().bittenByZombie(GetComponent<ZombieVars>().damage);
            // play chomping sound
            int chompID = Mathf.CeilToInt(Random.Range(0, chomps.Length));
            AudioClip thisChomp = chomps[chompID];
            if (Time.time > startChompingSound + 0.7 * thisChomp.length)
            {
                AudioSource.PlayClipAtPoint(thisChomp, Camera.main.transform.position, Globals.Instance.sfxVolume * RELATIVE_SFX_VOLUME);
                startChompingSound = Time.time;
            }
        }
    }
}
