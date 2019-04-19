using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupPlantToolbar : MonoBehaviour
{
    public GameObject toolbarPlantTemplate;
    public GameObject plantsParent;

    int numberSlotsMaximum = 9;
    int numberSlotsStarting = 6;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 planterSize = gameObject.GetComponent<Collider>().bounds.size;
        Vector3 toParentBottomLeft = new Vector3(-planterSize.x / 2, planterSize.y / 2, -planterSize.z / 2);
        Vector3 cellSize = new Vector3(planterSize.x / numberSlotsMaximum, 0.0f, planterSize.z);
        Vector3 toCellCenter = new Vector3(cellSize.x / 2, 0.0f, cellSize.z / 2);
        for (int i = 0; i < numberSlotsStarting; i++) // only create numberSlotsStarting slots
        {
            Vector3 cellPositionInGrid = new Vector3(i * cellSize.x, 0.0f, 0.0f);
            // as cells are spawned as Grand-CHILDREN of the Ground, so they automatically inherit transform from Ground
            GameObject newCell = (GameObject)Instantiate(toolbarPlantTemplate, transform.position + toParentBottomLeft + cellPositionInGrid + toCellCenter, plantsParent.transform.rotation, plantsParent.transform);
            newCell.transform.localScale = new Vector3(1.0f / numberSlotsMaximum, 1.0f, 1.0f);

            // unity sometimes doesn't set position, so set localPosition (https://answers.unity.com/questions/225729/gameobject-positionset-not-working.html)
            // also yOffset = 0.001 to prevent z-fighting with ground
            newCell.transform.localPosition = new Vector3(newCell.transform.localPosition.x, 0.001f, newCell.transform.localPosition.z);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
