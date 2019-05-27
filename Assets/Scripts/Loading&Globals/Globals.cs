using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour {
    // Singleton
    private Globals() { }
    public static Globals Instance { get; private set; }

    // __app in _preload scene
    public GameObject App { get; private set; }

    // MainController in __app in _preload scene
    public MainController controller { get; private set; }

    // get and change selected object
    public GameObject SelectedObject { get; set; }
    // get and change dragged object
    public GameObject DraggedObject { get; set; }
    // reset selected and dragged object
    public void ResetPlantSelection()
    {
        // only null (is pointer to toolbar plant)
        if (Globals.Instance.SelectedObject != null)
        {
            Globals.Instance.SelectedObject = null;
        }
        // destroy and null
        if (Globals.Instance.DraggedObject != null)
        {
            Destroy(Globals.Instance.DraggedObject);
            Globals.Instance.DraggedObject = null;
        }
    }

    // get and change sun score
    private int _sunScore;
    public static readonly int MAX_SCORE = 999;
    public int SunScore
    {
        get {
            return _sunScore;
        }
        set {
            _sunScore = Mathf.Min(value, MAX_SCORE);
        }
    }

    // sun icon on toolbar: where collected suns fly to
    public GameObject SunIcon { get; set; }

    // current music volume
    private float _musicVolume = 0.03f;
    public float musicVolume
    {
        get
        {
            return _musicVolume;
        }
        set
        {
            _musicVolume = value;
            GetComponent<Music>().changeVolume();
        }
    }

    // current SFX volume
    public float sfxVolume = 0.3f;
    
    // last played OR currently playing level
    internal int currentLevel = 1;
    internal TextAsset currentLevelFile;
    internal int zombiesLeftInLevel;

    // night or day
    internal bool isDay;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        App = gameObject;
        controller = GetComponent<MainController>();
    }
}
