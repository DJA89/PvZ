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

    // get and change sun score
    private int _sunScore = 1000; // enough to buy initial sunflower
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
    [ReadOnlyInInspector] public float musicVolume = 0.03f;

    // current SFX volume
    [ReadOnlyInInspector] public float sfxVolume = 0.3f;

    // currently playing OR last successfully ended level
    [HideInInspector] public int currentLevel = 0;
    [HideInInspector] public TextAsset currentLevelFile;
    [HideInInspector] public int zombiesLeftInLevel = 0;

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
