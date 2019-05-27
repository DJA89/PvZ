using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public GameObject game_over_panel;
    public GameObject losing_wall;
    public AudioClip sound;

    // Start is called before the first frame update
    void Start() {
        game_over_panel.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter()
    {
        // reset selected plant
        Globals.Instance.ResetPlantSelection();
        // a zombie got through the lawn == game over
        Globals.Instance.App.GetComponent<Music>().playEmptyMusic();
        AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position, Globals.Instance.sfxVolume);
        losing_wall.GetComponent<BoxCollider>().enabled = false;
        game_over_panel.SetActive(true);
    }

    public void RestartLevel()
    {
        Globals.Instance.controller.RestartCurrentLevel();
    }

    public void GoToMenuScreen()
    {
        Globals.Instance.controller.LoadMenu();
    }
}
