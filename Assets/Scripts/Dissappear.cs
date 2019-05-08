using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissappear : MonoBehaviour
{

    private int startingFrame;
    // Start is called before the first frame update
    void Start()
    {
        startingFrame = Time.frameCount;
    }

    // Update is called once per frame
    void Update()
    {
       if (Time.frameCount - startingFrame > 600)
        {
            Destroy(gameObject);
        }
    }
}
