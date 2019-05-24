using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour {
    // Singleton
    private Globals() { }
    public static Globals Instance { get; private set; }

    // __app in _preload scene
    public GameObject App { get; private set; }

    // get and change selected object
    public GameObject SelectedObject { get; set; }
    // get and change dragged object
    public GameObject DraggedObject { get; set; }

    // get and change sun score
    private int _sunScore = 1000; // enough to buy initial sunflower
    public static readonly int MAX_SCORE = 999;
    public int currentLevel;
    public TextAsset[] levels;
    public TextAsset level1;
    public TextAsset level2;
    public TextAsset level3;
    public TextAsset level4;
    public TextAsset level5;
    public TextAsset level6;


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
    public float musicVolume;

    // current SFX volume
    public float sfxVolume;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        App = gameObject;
    }

    private void Start()
    {
        levels = new TextAsset[6];
        levels[0] = level1;
        levels[1] = level2;
        levels[2] = level3;
        levels[3] = level4;
        levels[4] = level5;
        levels[5] = level6;
    }

    public TextAsset GetCurrentLevel()
    {
        return levels[currentLevel - 1];
    }
}
