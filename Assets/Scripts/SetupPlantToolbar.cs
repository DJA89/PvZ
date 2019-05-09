using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SetupPlantToolbar : MonoBehaviour
{
    public GameObject toolbarObject;
    public TextAsset plantsConfig;
    public GameObject toolbarPlantTemplates;
    public GameObject plantsList;

    int numberSlotsMaximum = 8;

    // Start is called before the first frame update
    void Start()
    {
        // load plant prices
        string[] lines = plantsConfig.ToString().Split(new string[] { "\n", "\r\n" }, StringSplitOptions.None);
        int[] plantCosts = new int[lines.Length];
        for (int i = 0; i < lines.Length; i++){
            string plantCost = lines[i].Split(',')[1].Trim();
            plantCosts[i] = System.Convert.ToInt32(plantCost);
        }

        Vector3 toolbarSize = toolbarObject.GetComponent<Collider>().bounds.size;
        Vector3 toParentFrontLeft = new Vector3(-toolbarSize.x / 2, toolbarSize.y / 2, -toolbarSize.z * 3 / 4);
        // 1 slot for sun + all plants
        Vector3 cellSize = new Vector3(toolbarSize.x / (numberSlotsMaximum + 1), 0.0f, toolbarSize.z);
        Vector3 toCellCenter = new Vector3(cellSize.x / 2, 0.0f, cellSize.z / 2);

        //// scale plantlist so plants templates don't get huge
        //Vector3 newPlantlistScale = plantsList.transform.localScale;
        //newPlantlistScale.x /= plantsList.transform.lossyScale.x;
        //newPlantlistScale.y /= plantsList.transform.lossyScale.y;
        //newPlantlistScale.z /= plantsList.transform.lossyScale.z;
        //plantsList.transform.localScale = newPlantlistScale;

        int plantsInToolbarCount = toolbarPlantTemplates.transform.childCount;
        for (int i = 0; i < plantsInToolbarCount; i++) // only create numberSlotsStarting slots
        {
            Vector3 cellPositionInGrid = new Vector3((i + 1) * cellSize.x, 0.0f, 0.0f); // i+1 because of sun slot
            // as cells are spawned as Grand-CHILDREN of the Ground, so they automatically inherit transform from Ground
            GameObject newToolbarPlant = toolbarPlantTemplates.transform.GetChild(i).gameObject;
            Vector3 newToolbarPlantPosition = transform.position + toParentFrontLeft + cellPositionInGrid + toCellCenter;
            GameObject newPlant = (GameObject)Instantiate(newToolbarPlant, newToolbarPlantPosition, plantsList.transform.rotation, plantsList.transform);
            // if has shoot script => disable it
            if (newPlant.GetComponent<Shoot>() != null)
            {
                newPlant.GetComponent<Shoot>().enabled = false;
            }
            newPlant.AddComponent<SelectPlant>();

            // unity sometimes doesn't set position, so set localPosition (https://answers.unity.com/questions/225729/gameobject-positionset-not-working.html)
            // also yOffset = 0.001 to prevent z-fighting with ground
            newPlant.transform.localPosition = new Vector3(newPlant.transform.localPosition.x, newPlant.transform.localPosition.y + 0.001f, newPlant.transform.localPosition.z);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
