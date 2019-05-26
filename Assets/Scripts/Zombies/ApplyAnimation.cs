using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyAnimation : MonoBehaviour
{
    /* 
     The reason for this script is that animations support translations only
     as absolute values and cannot blend with other movements. So it has to be
     applied to an empty GameObject and blended manually by this script.

     "Your animations should be animated in place. Unity don't support motion delta"
     (https://answers.unity.com/questions/55126/movement-and-animation.html)
     
     This solution was presented here:
     https://forum.unity.com/threads/animations-with-translation.32143/
    */

    private Vector3 lastFramePosition;
    private Quaternion startingRotation;

    // Start is called before the first frame update
    void Start()
    {
        // init last position
        lastFramePosition = transform.localPosition;
        startingRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        // get current, compute difference
        Vector3 currentFramePosition = transform.localPosition;
        Vector3 positionDifference = currentFramePosition - lastFramePosition;
        // add position, multiply rotations and apply scale to parent
        transform.parent.localPosition += positionDifference;
        transform.parent.localRotation = startingRotation * transform.localRotation;
        transform.parent.localScale = transform.localScale;
        // iterate
        lastFramePosition = currentFramePosition;
    }
}
