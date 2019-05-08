using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals {
    // Singleton
    private Globals() { }
    public static Globals Instance { get; } = new Globals();

    // get and change selected object
    public GameObject SelectedObject { get; set; }

    // get and change sun score
    public int SunScore { get; set; }
    //{
    //    get {
            
    //    }
    //    set {

    //    }
    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
