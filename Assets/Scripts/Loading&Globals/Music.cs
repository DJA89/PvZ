using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip mainMenuMusic;
    public AudioClip dayLevelMusic;
    public float musicFadeTime = 0.8F;

    enum Fade { In, Out };
    private AudioSource currentMusic;
    private AudioSource lastMusic;

    private void Start()
    {
        Debug.Log("Music.Start");
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
        Debug.Log("Music.playMainMenuMusic");
        fadeOutChangeMusic(mainMenuMusic);
    }

    public void playDayLevelMusic()
    {
        Debug.Log("Music.playDayLevelMusic");
        fadeOutChangeMusic(dayLevelMusic);
    }

    private void fadeOutChangeMusic(AudioClip newMusic)
    {
        // swap current and last
        var tmp = lastMusic;
        lastMusic = currentMusic;
        currentMusic = tmp;
        // assign new current
        currentMusic.clip = newMusic;
        currentMusic.volume = Globals.Instance.musicVolume;
        currentMusic.PlayScheduled(AudioSettings.dspTime + 2);
        // fade out
        StartCoroutine(FadeAudio(lastMusic, musicFadeTime, Fade.Out));
    }

    private void crossFadeChangeMusic(AudioClip newMusic)
    {
        // swap current and last
        AudioSource tmp = lastMusic;
        lastMusic = currentMusic;
        currentMusic = tmp;
        // assign new current
        currentMusic.clip = newMusic;
        currentMusic.PlayScheduled(AudioSettings.dspTime + 0.8);
        // cross fade
        StartCoroutine(FadeAudio(lastMusic, musicFadeTime, Fade.Out));
        StartCoroutine(FadeAudio(currentMusic, musicFadeTime, Fade.In));
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
