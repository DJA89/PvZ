using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{

    public GameObject levelCompletePanel;
    public GameObject nextLevelButton;
    public AudioClip sound;
    private float RELATIVE_SFX_VOLUME = 0.5f;
    private bool levelComplete;

    // Start is called before the first frame update
    void Start()
    {
        levelComplete = false;
        levelCompletePanel.SetActive(false);
    }

    void Update()
    {
        if (!levelComplete && Globals.Instance.zombiesLeftInLevel <= 0)
        {
            // run this only once
            levelComplete = true;
            // reset selected plant
            Globals.Instance.ResetPlantSelection();
            // defeated all zombies == completed level
            Globals.Instance.App.GetComponent<Music>().playEmptyMusic();
            AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position, Globals.Instance.sfxVolume * RELATIVE_SFX_VOLUME);
            levelCompletePanel.SetActive(true);
            // if there is no next level, don't show the next level button
            if (!Globals.Instance.controller.ExistsNextLevel())
            {
                nextLevelButton.SetActive(false);
            }
        }
    }

    public void NextLevel()
    {
        Globals.Instance.controller.LoadNextLevel();
    }

    public void RestartLevel()
    {
        Globals.Instance.controller.RestartCurrentLevel();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        Globals.Instance.controller.LoadMenu();
    }

    //public void LevelMenu()
    //{
    //    Globals.Instance.controller.LoadMenu();
    //}
}
