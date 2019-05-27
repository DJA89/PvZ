using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SliderRelease : MonoBehaviour, IPointerUpHandler
{
    public AudioClip sound;
    float RELATIVE_SFX_VOLUME = 0.1f;

    public void OnPointerUp(PointerEventData eventData)
    {
        // play test sound
        AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position, Globals.Instance.sfxVolume * RELATIVE_SFX_VOLUME);
    }
}
