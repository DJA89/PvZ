using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager {
    // Singleton
    private SelectionManager() { }
    public static SelectionManager Instance { get; } = new SelectionManager();

    // get and change selected object
    public GameObject Selected { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
