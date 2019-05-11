using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieLife : MonoBehaviour
{

    public GameObject zombie;
    public int life;
    // Start is called before the first frame update
    void Start()
    {
        life = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
         if(collision.gameObject.tag == "damagingObject")
        {
            life--;
            if (life == 0)
            {
                Destroy(gameObject, 1.0F);
            }
        }
         
    }
}
