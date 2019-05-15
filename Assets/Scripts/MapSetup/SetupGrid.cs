using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupGrid : MonoBehaviour
{
    public GameObject GroundObject;
    public GameObject fieldCellPrefab;
    public GameObject cellsParent;

    int numberCellsX= 9;
    int numberCellsZ = 5;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 groundSize = GroundObject.GetComponent<Collider>().bounds.size;
        Vector3 toGroundBottomLeft = new Vector3(- groundSize.x / 2, 0.0f, - groundSize.z /2);
        Vector3 cellSize = new Vector3(groundSize.x / numberCellsX, 0.0001f, groundSize.z / numberCellsZ);
        Vector3 toCellCenter = new Vector3(cellSize.x / 2, 0.0f, cellSize.z / 2);
        for (int i = 0; i < numberCellsX; i++)
        {
            for (int j = 0; j < numberCellsZ; j++)
            {
                Vector3 cellPositionInGrid = new Vector3(i * cellSize.x, 0.0f, j * cellSize.z);
                Vector3 absolutePosition = toGroundBottomLeft + cellPositionInGrid + toCellCenter;
                GameObject newCell = (GameObject)Instantiate(fieldCellPrefab, toGroundBottomLeft + cellPositionInGrid + toCellCenter, cellsParent.transform.rotation, cellsParent.transform);
                newCell.GetComponent<BoxCollider>().size = cellSize;
                newCell.GetComponent<CellVars>().lane = j;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
