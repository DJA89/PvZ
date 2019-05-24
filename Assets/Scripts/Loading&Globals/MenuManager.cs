using System.Collections;
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

    public void LoadNextLevel()
    {
        Globals.Instance.controller.LoadNextLevel();
    }

    public void LoadLevel(int levelID)
    {
        Globals.Instance.controller.LoadLevel(levelID);
    }

    public void ShowOptions()
    {
        // TODO
    }

    public void QuitGame()
    {
        Globals.Instance.controller.QuitGame();
    }
}
