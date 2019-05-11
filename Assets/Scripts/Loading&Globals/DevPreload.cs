using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevPreload : MonoBehaviour
{
    // this should run absolutely first; use script-execution-order to do so.
    // (of course, normally never use the script-execution-order feature,
    // this is an unusual case, just for development.)
    void Awake()
    {
        GameObject check = GameObject.Find("__app");
        if (check == null) {
            UnityEngine.SceneManagement.SceneManager.LoadScene("_preload");
        }
    }
}
