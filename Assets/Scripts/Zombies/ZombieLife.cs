using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieLife : MonoBehaviour
{

    public GameObject zombie;
    public float life;
    public AudioClip freezeSound;
    float RELATIVE_SFX_VOLUME = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void hitByBullet(GameObject bullet, float hitDamage)
    {
        life -= hitDamage;
        if(bullet.GetComponent<BulletVars>().type == 1)
        {
            gameObject.GetComponent<ZombieVars>().state = 1; // freeze zombie
            GetComponent<Renderer>().material.color = Color.white * 0.3f + Color.blue * 0.7f;
            gameObject.GetComponent<ZombieVars>().frozen_frame = Time.frameCount;
            AudioSource.PlayClipAtPoint(freezeSound, Camera.main.transform.position, Globals.Instance.sfxVolume * RELATIVE_SFX_VOLUME);
        }
        if (life <= 0)
        {
            Destroy(gameObject, 1.0F);
        }
    }
}
