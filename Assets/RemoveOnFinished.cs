using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveOnFinished : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // if has finished playing, remove
        if (!gameObject.GetComponent<ParticleSystem>().isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
