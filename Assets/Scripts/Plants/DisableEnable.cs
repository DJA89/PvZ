using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEnable : MonoBehaviour
{
    public static void Disable(GameObject plant)
    {
        // disable shooting (if plant can shoot)
        if (plant.GetComponent<Shoot>() != null)
        {
            plant.GetComponent<Shoot>().enabled = false;
        }
        // disable sunflower production (if plant does so)
        if (plant.GetComponent<SunflowerMakeSun>() != null)
        {
            plant.GetComponent<SunflowerMakeSun>().enabled = false;
        }
        // disable sunshroom production (if plant does so)
        if (plant.GetComponent<SunShroomMakeSun>() != null)
        {
            plant.GetComponent<SunShroomMakeSun>().enabled = false;
        }
        // disable animations (if plant has any)
        if (plant.GetComponent<Animator>() != null)
        {
            plant.GetComponent<Animator>().enabled = false;
        }
        // disable physics on collider
        if (plant.GetComponent<BoxCollider>() != null)
        {
            plant.GetComponent<BoxCollider>().isTrigger = true;
        }
    }

    public static void Enable(GameObject plant)
    {
        // enable shooting (if plant can shoot)
        if (plant.GetComponent<Shoot>() != null)
        {
            plant.GetComponent<Shoot>().enabled = true;
        }
        // enable sunflower production (if plant does so)
        if (plant.GetComponent<SunflowerMakeSun>() != null)
        {
            plant.GetComponent<SunflowerMakeSun>().enabled = true;
        }
        // enable sunshroom production (if plant does so)
        if (plant.GetComponent<SunShroomMakeSun>() != null)
        {
            plant.GetComponent<SunShroomMakeSun>().enabled = true;
        }
        // enable animations (if plant has any)
        if (plant.GetComponent<Animator>() != null)
        {
            plant.GetComponent<Animator>().enabled = true;
        }
        // enable physics on collider
        if (plant.GetComponent<BoxCollider>() != null)
        {
            plant.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
