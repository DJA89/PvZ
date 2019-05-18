using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour
{

    public float speed;
    private float frozenSpeed;

    // Start is called before the first frame update
    void Start()
    {
        frozenSpeed = speed / 2;
    }

    private void Update()
    {
        // doesnt slow down
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }

    public void freeze()
    {
        // half the movement speed
        speed = frozenSpeed;
    }
}
