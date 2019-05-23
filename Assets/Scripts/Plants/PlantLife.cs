using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantLife : MonoBehaviour
{
    public float life;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "zombie")
        {
            life -= collision.gameObject.GetComponent<ZombieVars>().damage;
            if (life <= 0)
            {
                Destroy(gameObject, 0F);
            }
        }
    }

    public void hitByBullet(float damage)
    {
        life -= damage;
        if (life <= 0)
        {
            Destroy(gameObject, 0F);
        }
    }
}
