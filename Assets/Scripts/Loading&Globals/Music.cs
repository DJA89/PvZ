using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip mainMenuMusic;
    public AudioClip dayLevelMusic;
    public AudioClip nightLevelMusic;
    public AudioClip emptyMusic;
    public float musicFadeTime = 0.8F;

    enum Fade { In, Out };
    private AudioSource currentMusic;
    private AudioSource lastMusic;
    private Coroutine currentFader;
    private Coroutine lastFader;

    private void Start()
    {
        // create audio sources
        currentMusic = gameObject.AddComponent<AudioSource>();
        currentMusic.loop = true;
        currentMusic.volume = 1;
        lastMusic = gameObject.AddComponent<AudioSource>();
        lastMusic.loop = true;
        lastMusic.volume = 0;
    }

    public void playMainMenuMusic()
    {
        fadeOutChangeMusic(mainMenuMusic);
    }

    public void playDayLevelMusic()
    {
        fadeOutChangeMusic(dayLevelMusic);
    }

    public void playNightLevelMusic()
    {
        fadeOutChangeMusic(nightLevelMusic);
    }

    public void playEmptyMusic()
    {
        fadeOutChangeMusic(emptyMusic);
    }

    private void fadeOutChangeMusic(AudioClip newMusic)
    {
        changeMusic(newMusic);
        currentMusic.volume = Globals.Instance.musicVolume;
        // fade out
        if (lastFader != null)
        {
            StopCoroutine(lastFader);
        }
        lastFader = StartCoroutine(FadeAudio(lastMusic, musicFadeTime, Fade.Out));
    }

    private void crossFadeChangeMusic(AudioClip newMusic)
    {
        changeMusic(newMusic);
        // cross fade
        if (lastFader != null)
        {
            StopCoroutine(lastFader);
        }
        if (currentFader != null)
        {
            StopCoroutine(currentFader);
        }
        lastFader = StartCoroutine(FadeAudio(lastMusic, musicFadeTime, Fade.Out));
        currentFader = StartCoroutine(FadeAudio(currentMusic, musicFadeTime, Fade.In));
    }

    internal void changeVolume()
    {
        currentMusic.volume = Globals.Instance.musicVolume;
    }

    private void changeMusic(AudioClip newMusic)
    {
        // swap current and last
        AudioSource tmp = lastMusic;
        lastMusic = currentMusic;
        currentMusic = tmp;
        // assign new current
        currentMusic.clip = newMusic;
        currentMusic.PlayScheduled(AudioSettings.dspTime + 2);
    }

    IEnumerator FadeAudio(AudioSource music, float timer, Fade fadeType)
    {
        float maxVolume = Globals.Instance.musicVolume;
        float start = fadeType == Fade.In ? 0.0F : maxVolume;
        float end = fadeType == Fade.In ? maxVolume : 0.0F;
        float i = 0.0F;
        float step = 1.0F / timer;

        while (i <= 1.0F && music != null)
        {
            i += step * Time.deltaTime;
            music.volume = Mathf.Lerp(start, end, i);
            yield return new WaitForSeconds(step * Time.deltaTime);
        }
    }
}
