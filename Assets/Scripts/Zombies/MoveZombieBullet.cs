using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveZombieBullet : MonoBehaviour
{
    private float speed = 10;

    // Update is called once per frame
    void Update()
    {
        // doesnt slow down
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
}
