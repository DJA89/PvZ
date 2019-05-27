using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuPlane;
    public GameObject levelMenuPlane;
    public GameObject optionsMenuPlane;
    public GameObject musicVolumeSlider;
    public GameObject sfxVolumeSlider;

    // Options
    private float musicVolume;
    private float sfxVolume;

    private void Start()
    {
        LoadMainMenu();
        optionsMenuPlane.SetActive(false);
    }

    public void LoadMainMenu()
    {
        mainMenuPlane.SetActive(true);
        levelMenuPlane.SetActive(false);
    }

    public void LoadLevelMenu()
    {
        mainMenuPlane.SetActive(false);
        levelMenuPlane.SetActive(true);
    }

    public void ShowOptions()
    {
        // show options overlay
        optionsMenuPlane.SetActive(true);
        // backup current config
        musicVolume = Globals.Instance.musicVolume;
        sfxVolume = Globals.Instance.sfxVolume;
        // apply current volume to sliders
        musicVolumeSlider.GetComponent<Slider>().value = musicVolume;
        sfxVolumeSlider.GetComponent<Slider>().value = sfxVolume;
    }

    public void DontSaveAndCloseOptions()
    {
        // hide options overlay
        optionsMenuPlane.SetActive(false);
        // restore backupped config
        Globals.Instance.musicVolume = musicVolume;
        Globals.Instance.sfxVolume = sfxVolume;
    }

    public void SaveAndCloseOptions()
    {
        // hide options overlay
        optionsMenuPlane.SetActive(false);
        // keep current config (do nothing)
    }

    public void SetMusicVolume()
    {
        Globals.Instance.musicVolume = musicVolumeSlider.GetComponent<Slider>().value;
    }

    public void SetSFXVolume()
    {
        Globals.Instance.sfxVolume = sfxVolumeSlider.GetComponent<Slider>().value;
    }

    public void LoadThisLevel()
    {
        Globals.Instance.controller.RestartCurrentLevel();
    }

    public void LoadLevel(int levelID)
    {
        Globals.Instance.controller.LoadLevel(levelID);
    }

    public void QuitGame()
    {
        Globals.Instance.controller.QuitGame();
    }
}
