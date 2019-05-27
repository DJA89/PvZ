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
        // reset Globals
        //Globals.Instance.SunScore = 50; // enough to buy initial sunflower
        Globals.Instance.SunScore = 1000;
        Globals.Instance.zombiesLeftInLevel = 0;
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
        Globals.Instance.App.GetComponent<Music>().playDayLevelMusic();
        SceneManager.LoadScene("Main");
    }

    public void GoToMenuScreen()
    {

        Globals.Instance.App.GetComponent<Music>().playMainMenuMusic();
        SceneManager.LoadScene("Menu");
    }
}
