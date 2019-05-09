using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlacePlant : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IDropHandler
{
    private GameObject plantShadow;

    private const float opacity = 0.5f;

    public void OnPointerEnter(PointerEventData eventData)
    {
        GameObject selectedPlant = Globals.Instance.SelectedObject;
        // if currently dragging plant (i.e. a plant is selected)
        if (selectedPlant != null)
        {
            // if cell is free
            if (transform.childCount == 0)
            {
                // show shadow of plant
                plantShadow = spawnPlantAsChild(selectedPlant);
                //SetRendererAlphas(opacity, GetComponentsInChildren<Renderer>()); // make semi-transparent
                plantShadow.GetComponent<Renderer>().material.color -= new Color(0, 0, 0, 1 - opacity);
                // disable shooting
                if (plantShadow.GetComponent<Shoot>() != null)
                {
                    plantShadow.GetComponent<Shoot>().enabled = false;
                }
                // dont raycast shadow object
                plantShadow.layer = 2; // Ignore Raycast Layer
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // place selected plant (like onDrop)
        // TODO
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


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject selectedPlant = Globals.Instance.SelectedObject;
        // if currently dragging plant (i.e. a plant is selected)
        if (selectedPlant != null)
        {
            // place plant if cell empty (i.e. only shadow present)
            if (transform.childCount == 1 && transform.GetChild(0).gameObject == plantShadow)
            {
                // remove shadow
                Destroy(plantShadow);
                plantShadow = null;
                // pay price for plant
                Globals.Instance.SunScore -= 100;
                // plant the selected plant on this cell
                GameObject newPlant = spawnPlantAsChild(selectedPlant);
                // remove select script (make non-selectable)
                Destroy(newPlant.GetComponent<SelectPlant>());
                // enable shooting (if plant can shoot)
                if (newPlant.GetComponent<Shoot>() != null)
                {
                    newPlant.GetComponent<Shoot>().enabled = true;
                }
                newPlant.layer = 9;
            }
        }
    }

    private GameObject spawnPlantAsChild(GameObject template)
    {
        Vector3 plantSpawnPoint = new Vector3(0.0f, 0.0f, 0); //-0.75f); // relative to (parent) cell
        GameObject newPlant = (GameObject)Instantiate(template, plantSpawnPoint + transform.position, transform.rotation, transform);
        // divide by absolute (lossy) cell scale (otherwise plant gets squashed)
        Vector3 newPlantScale = newPlant.transform.localScale;
        newPlantScale.x /= transform.lossyScale.x;
        newPlantScale.y /= transform.lossyScale.y;
        newPlantScale.z /= transform.lossyScale.z;
        newPlant.transform.localScale = newPlantScale;
        // and move it to top of cell
        float sizeY = gameObject.GetComponent<Collider>().bounds.size.y;
        newPlant.transform.position += new Vector3(0.0f, sizeY / 2, 0.0f);
        return newPlant;
    }
}
