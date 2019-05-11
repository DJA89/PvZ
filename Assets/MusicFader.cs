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
        FadeAudio(musicFadeTime, Fade.Out);
    }

    internal void FadeIn()
    {
        FadeAudio(musicFadeTime, Fade.In);
    }

    void FadeAudio(float timer, Fade fadeType)
    {
        AudioSource currentAudio = Globals.Instance.AudioManager.GetComponent<AudioSource>();
        float defaultVolume = currentAudio.volume;
        float start = fadeType == Fade.In ? 0.0F : defaultVolume;
        float end = fadeType == Fade.In ? defaultVolume : 0.0F;
        float i = 0.0F;
        float step = 1.0F / timer;

        while (i <= 1.0F)
        {
            i += step * Time.deltaTime;
            currentAudio.volume = Mathf.Lerp(start, end, i);
            new WaitForSeconds(step * Time.deltaTime);
        }
    }
}
