using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private void Start()
    {
        Globals.Instance.AudioManager = gameObject;
    }

}
