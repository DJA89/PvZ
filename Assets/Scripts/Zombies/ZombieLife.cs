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

    public void hitByBullet(GameObject bullet, float hitDamage)
    {
        life -= hitDamage;
        if(bullet.GetComponent<BulletVars>().type == 1)
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
