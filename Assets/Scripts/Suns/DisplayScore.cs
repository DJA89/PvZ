using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int currentSunScore = Globals.Instance.SunScore;
        string scoreString = string.Format("{0,3:##0}", currentSunScore);
        gameObject.GetComponent<TextMesh>().text = scoreString;
    }
}
