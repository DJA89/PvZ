using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieLife : MonoBehaviour
{

    public GameObject zombie;
    public float life;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void hitByBullet(float hitDamage)
    {
        life -= hitDamage;
        if (life <= 0)
        {
            life -= collision.gameObject.GetComponentInParent<PlantVars>().damage;
            if(collision.gameObject.name == "SnowBullet")
            {
                gameObject.GetComponent<ZombieVars>().state = 1;
                gameObject.GetComponent<ZombieVars>().frozen_frame = Time.frameCount;
            }
            if (life <= 0)
            {
                Destroy(gameObject, 1.0F);
            }
        }
    }
}
