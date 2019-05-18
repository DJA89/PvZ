using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public AudioClip sound;
    public ParticleSystem splash;
    float RELATIVE_SFX_VOLUME = 0.1f;

    private void OnTriggerEnter(Collider other)
    {
        // hitting sound
        AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position, Globals.Instance.sfxVolume * RELATIVE_SFX_VOLUME);
        // hitting particles
        // the particles should come out from the zombie, but at bullet height
        Vector3 bulletPosition = transform.position;
        Vector3 zombiePosition = other.transform.position;
        Vector3 midPosition = (bulletPosition + zombiePosition) / 2;
        Vector3 splashPosition = new Vector3(midPosition.x, bulletPosition.y, midPosition.z);
        ParticleSystem newSplash = (ParticleSystem)Instantiate(splash, splashPosition, transform.rotation);
        // remove bullet
        Destroy(gameObject);
    }
}
