using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingPlants : MonoBehaviour
{
    private Vector3 startScale = new Vector3(0.01f, 0.01f, 0.01f);
    private Vector3 grownScale;
    private bool growing = false;
    private float growingStartTime;
    private float growingTotalTime;

    // Start is called before the first frame update
    void Start()
    {
        //
        Vector3 oldPos = transform.position;
        oldPos.z -= 0.1f;
        transform.position = oldPos;

        grownScale = transform.localScale;
        growingTotalTime = GetComponent<PlantVars>().rechargeTime;
        growing = true;
        growingStartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (growing)
        {
            float lerp = (Time.time - growingStartTime) / growingTotalTime;
            if (lerp <= 1)
            {
                transform.localScale = lerp * grownScale;
            }
            else
            {
                growing = false;
            }
        }
    }
}
