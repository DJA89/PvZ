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

    // load level 1-6
    public void LoadLevel(int levelID)
    {
        //string levelName = "level" + levelID;
        //SceneManager.LoadScene(levelName, LoadSceneMode.Single);
        SceneManager.LoadScene("Main");
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
}
