using UnityEngine;
using System.Collections;

public class OffScreen : MonoBehaviour
{

    private int offScreenCoordinate;

    private void Start()
    {
        offScreenCoordinate = 17;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 17)
        {
            Destroy(gameObject, 0F);
        }
    }
}
