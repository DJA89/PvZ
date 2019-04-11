using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupGrid : MonoBehaviour
{
    public GameObject fieldCellPrefab;
    public GameObject cellsParent;

    int numberCellsX= 9;
    int numberCellsZ = 5;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 groundSize = gameObject.GetComponent<Collider>().bounds.size;
        Vector3 toGroundBottomLeft = new Vector3(- groundSize.x / 2, 0.0f, - groundSize.z /2);
        Vector3 cellSize = new Vector3(groundSize.x / numberCellsX, 0.0f, groundSize.z / numberCellsZ);
        Vector3 toCellCenter = new Vector3(cellSize.x / 2, 0.0f, cellSize.z / 2);
        for (int i = 0; i < numberCellsX; i++)
        {
            for (int j = 0; j < numberCellsZ; j++)
            {
                Vector3 cellPositionInGrid = new Vector3(i * cellSize.x, 0.0f, j * cellSize.z);
                // as cells are spawned as Grand-CHILDREN of the Ground, so they automatically inherit transform from Ground
                GameObject newCell = (GameObject)Instantiate(fieldCellPrefab, toGroundBottomLeft + cellPositionInGrid + toCellCenter, Quaternion.identity, cellsParent.transform);
                newCell.transform.localScale = new Vector3(1.0f / numberCellsX, 1.0f, 1.0f / numberCellsZ);
                Debug.Log(newCell.transform.localScale.y);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
