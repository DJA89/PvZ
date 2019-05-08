using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Plant")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
        Destroy(gameObject, 0.5F);
    }
}
