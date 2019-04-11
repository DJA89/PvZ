﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlacePlant : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject plant1Template;
    
    private GameObject plantShadow;
    private Renderer cellRenderer;
    private Color cellColor;

    public void OnPointerEnter(PointerEventData eventData)
    {
        cellRenderer = gameObject.GetComponent<Renderer>();
        cellRenderer.material.color = Color.blue;

        // no children => cell free
        if (transform.childCount == 0) // no children => cell free
        {
            // show shadow of plant
            plantShadow = spawnPlant(); // spawn
            SetRendererAlphas(0.5f, GetComponentsInChildren<Renderer>()); // make semi-transparent
            plantShadow.GetComponent<Shoot>().enabled = false; // don't shoot
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        cellRenderer = gameObject.GetComponent<Renderer>();
        cellRenderer.material.color = Color.red;

        // only shadow present?
        if (transform.childCount == 1 && transform.GetChild(0).gameObject == plantShadow)
        {
            // remove shadow
            Destroy(plantShadow);
            plantShadow = null;
            // spawn real plant
            GameObject newPlant = spawnPlant();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // if we have a shadow
        if (plantShadow != null)
        {
            // remove shadow
            Destroy(plantShadow);
            plantShadow = null;
        }
    }

    private void SetRendererAlphas(float alpha, Renderer[] mRenderers)
    {
        // from https://answers.unity.com/questions/1031416/make-a-complex-object-semi-transparent-without-cha.html
        for (int i = 0; i < mRenderers.Length; i++)
        {
            for (int j = 0; j < mRenderers[i].materials.Length; j++)
            {
                Color matColor = mRenderers[i].materials[j].color;
                matColor.a = alpha;
                mRenderers[i].materials[j].color = matColor;
            }
        }
    }

private GameObject spawnPlant()
    {
        Vector3 plantSpawnPoint = new Vector3(0.0f, 0.0f, -0.75f); // relative to (parent) cell
        GameObject newPlant = (GameObject)Instantiate(plant1Template, plantSpawnPoint + transform.position, transform.rotation, transform);
        // divide by absolute (lossy) cell scale (otherwise plant gets squashed)
        Vector3 newPlantScale = newPlant.transform.localScale;
        newPlantScale.x /= transform.lossyScale.x;
        newPlantScale.y /= transform.lossyScale.y;
        newPlantScale.z /= transform.lossyScale.z;
        newPlant.transform.localScale = newPlantScale;
        return newPlant;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
