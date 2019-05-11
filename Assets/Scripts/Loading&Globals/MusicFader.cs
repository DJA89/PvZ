using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFader : MonoBehaviour
{
    enum Fade { In, Out };
    public float musicFadeTime = 0.8F;

    public void FadeOut()
    {
        StartCoroutine(FadeAudio(musicFadeTime, Fade.Out));
    }

    public void FadeIn()
    {
        StartCoroutine(FadeAudio(musicFadeTime, Fade.In));
    }

    IEnumerator FadeAudio(float timer, Fade fadeType)
    {
        AudioSource currentAudio = Globals.Instance.AudioManager.GetComponent<AudioSource>();
        float defaultVolume = currentAudio.volume;
        float start = fadeType == Fade.In ? 0.0F : defaultVolume;
        float end = fadeType == Fade.In ? defaultVolume : 0.0F;
        float i = 0.0F;
        float step = 1.0F / timer;

        while (i <= 1.0F && currentAudio != null)
        {
            i += step * Time.deltaTime;
            currentAudio.volume = Mathf.Lerp(start, end, i);
            yield return new WaitForSeconds(step * Time.deltaTime);
        }
    }
}
