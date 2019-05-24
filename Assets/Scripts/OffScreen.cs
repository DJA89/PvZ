using UnityEngine;
using System.Collections;

public class OffScreen : MonoBehaviour
{


    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 17 || transform.position.x < -17)
        {
            Destroy(gameObject, 0F);
        }
    }
}
