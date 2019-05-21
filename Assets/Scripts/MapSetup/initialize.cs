using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initialize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Aqui estoy");
        gameObject.GetComponent<Renderer>().material.SetInt("_ZWrite", -1);
        Debug.Log("Aqui sali");
    }
}
