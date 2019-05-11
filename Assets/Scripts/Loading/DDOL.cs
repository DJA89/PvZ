using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOL : MonoBehaviour
{
    // see https://stackoverflow.com/questions/35890932/unity-game-manager-script-works-only-one-time/35891919#35891919
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // add all general things, e.g. SOUNDS, SCORING, DB, ... to THIS gameobject (in this script or in onthers)
}
