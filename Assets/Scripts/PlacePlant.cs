using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePlant : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // left mouse button
        {
            Debug.Log("Pressed primary button.");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
            {
                if (hit.collider.transform.gameObject)
                print("HIT");
            }
        }
    }
}
