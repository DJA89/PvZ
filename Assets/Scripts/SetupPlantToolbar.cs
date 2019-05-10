using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SetupPlantToolbar : MonoBehaviour
{
    public TextAsset plantsConfig;
    public GameObject toolbarObject;
    public GameObject toolbarPlantTemplates;
    public GameObject priceTagTemplates;
    public GameObject plantList;

    int numberSlotsMaximum = 8;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 toolbarSize = toolbarObject.GetComponent<Collider>().bounds.size;
        Vector3 toParentFrontLeft = new Vector3(-toolbarSize.x / 2, toolbarSize.y / 2, -toolbarSize.z * 3 / 4);
        // 1 slot for sun + all plants
        Vector3 cellSize = new Vector3(toolbarSize.x / (numberSlotsMaximum + 1), 0.0f, toolbarSize.z);
        Vector3 toCellCenter = new Vector3(cellSize.x / 2, 0.0f, cellSize.z / 2);
        
        int plantsInToolbarCount = toolbarPlantTemplates.transform.childCount;
        for (int i = 0; i < plantsInToolbarCount; i++) // only create numberSlotsStarting slots
        {
            // get new cell
            Vector3 cellPositionInGrid = new Vector3((i + 1) * cellSize.x, 0.0f, 0.0f); // i+1 because of sun slot

            // create new plant
            GameObject plantTemplate = toolbarPlantTemplates.transform.GetChild(i).gameObject;
            Vector3 newPlantPosition = transform.position + toParentFrontLeft + cellPositionInGrid + toCellCenter;
            GameObject newPlant = (GameObject)Instantiate(plantTemplate, newPlantPosition, plantList.transform.rotation, plantList.transform);
            // if has shoot script => disable it
            if (newPlant.GetComponent<Shoot>() != null)
            {
                newPlant.GetComponent<Shoot>().enabled = false;
            }
            newPlant.AddComponent<SelectPlant>();
            // add price to plant
            newPlant.AddComponent<PlantVars>();
            newPlant.GetComponent<PlantVars>().plantPrice = plantTemplate.GetComponent<PlantVars>().plantPrice;
            // unity sometimes doesn't set position, so set localPosition (https://answers.unity.com/questions/225729/gameobject-positionset-not-working.html)
            // also yOffset = 0.001 to prevent z-fighting with ground
            newPlant.transform.localPosition = new Vector3(newPlant.transform.localPosition.x, newPlant.transform.localPosition.y + 0.001f, newPlant.transform.localPosition.z);

            // create new price tag
            GameObject priceTagTemplate = priceTagTemplates.transform.GetChild(0).gameObject;
            float priceTagPositionX = (transform.position + toParentFrontLeft + cellPositionInGrid + toCellCenter).x - 0.8f;
            Vector3 priceTagPosition = priceTagTemplate.transform.position + new Vector3(priceTagPositionX, 0, 0);
            GameObject newPriceTag = (GameObject)Instantiate(priceTagTemplate, priceTagPosition, plantList.transform.rotation, plantList.transform);
            string priceString = string.Format("{0,3:##0}", newPlant.GetComponent<PlantVars>().plantPrice);
            newPriceTag.GetComponent<TextMesh>().text = priceString;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
