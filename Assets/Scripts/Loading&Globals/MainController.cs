using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    public TextAsset[] levels;

    // Start is called before the first frame update
    void Start()
    {
        // load main menu
        GetComponent<Music>().playMainMenuMusic();
        SceneManager.LoadScene("Menu");
    }

    // load level 1-6
    //public void LoadLevel(int levelID)
    //{
    //    // day level
    //    if (1 <= levelID && levelID <= 3)
    //    {
    //        // level file exists
    //        if (levelID-1 < levels.Length)
    //        {
    //            // load zombie layout
    //            GetComponent<Globals>().currentLevel = levelID;
    //            GetComponent<Globals>().currentLevelFile = levels[levelID-1];
    //            // play music
    //            GetComponent<Music>().playDayLevelMusic();
    //            // load main scene
    //            SceneManager.LoadScene("Main");
    //            Debug.Log("loaded level " + levelID);
    //        }
    //    }
    //    // night level
    //    else if (4 <= levelID && levelID <= 6)
    //    {
    //    }
    //}

    //public void LoadNextLevel()
    //{
    //    int nextLevel = GetComponent<Globals>().currentLevel + 1;
    //    LoadLevel(nextLevel);
    //    GetComponent<Globals>().currentLevel = nextLevel;
    //}

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
