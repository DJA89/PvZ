using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSpawner : MonoBehaviour
{

    public GameObject sun;
    public float rate;
    public float startingProbability;
    public Vector3 firstCell;
    private Vector3[,] cells;
    private float frameCount;
    // Start is called before the first frame update

    void Start()
    {
        frameCount = 0f;
        cells = new Vector3[5, 9];

        cells[0, 0] = firstCell; // new Vector3(-8f, -2f, -2f);
        Vector3 cellDiffVert = new Vector3(0, 0, 3f);
        Vector3 cellDiffHor = new Vector3(2f, 0, 0);

        for (int i = 1; i < 5; i++)
        {
            cells[i, 0] = cells[i - 1, 0] + cellDiffVert;
        }

        for (int j = 1; j < 9; j++)
        {
            for (int k = 0; k < 5; k++)
            {
                cells[k, j] = cells[k, j - 1] + cellDiffHor;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        frameCount++;
        float currentProbability = startingProbability + (100 - startingProbability) * frameCount / rate;
        float random = Random.Range(0.0f, 100.0f);
        if (random < currentProbability)
        {
            frameCount = 0f;
            Debug.Log(random + " < " + currentProbability);
            int cellMin = Mathf.Min(Random.Range(0, 5), 4);
            int cellMax = Mathf.Min(Random.Range(0, 9), 8);
            //Debug.Log("cellMin: " + cellMin + "; CellMax: " + cellMax + "; Value: " + cells[cellMin, cellMax]);

            GameObject newSun = (GameObject) Instantiate(sun, cells[cellMin, cellMax], transform.rotation);
        }
    }
}
