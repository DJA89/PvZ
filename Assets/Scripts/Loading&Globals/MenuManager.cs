﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuPlane;
    public GameObject levelMenuPlane;

    private void Start()
    {
        LoadMainMenu();
    }

    // load level 1-6
    public void LoadLevel(int levelID)
    {
        Globals.Instance.App.GetComponent<Music>().playDayLevelMusic();
        //string levelName = "level" + levelID;
        //SceneManager.LoadScene(levelName, LoadSceneMode.Single);
        SceneManager.LoadScene("Main");
    }

    public void LoadMainMenu()
    {
        Globals.Instance.App.GetComponent<Music>().playMainMenuMusic();
        mainMenuPlane.SetActive(true);
        levelMenuPlane.SetActive(false);
    }

    public void LoadLevelMenu()
    {
        mainMenuPlane.SetActive(false);
        levelMenuPlane.SetActive(true);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
