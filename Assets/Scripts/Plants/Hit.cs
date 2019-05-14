using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public AudioClip sound;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject, 0.5F);
        AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position, Globals.Instance.sfxVolume);
    }
}
