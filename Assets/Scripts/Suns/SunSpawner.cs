using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSpawner : MonoBehaviour
{

    public GameObject sun;
    private float lastSpawnTime;
    public readonly float minSunSpawnTime = 5; // in seconds
    public readonly float maxSunSpawnTime = 8; // in seconds
    public Vector3 firstCell;
    private Vector3[,] cells;

    // Start is called before the first frame update
    void Start()

    {
        TextAsset levelFile = Globals.Instance.GetCurrentLevel();
        string[] lines = levelFile.ToString().Split(new string[] { "\n", "\r\n" }, System.StringSplitOptions.None);
        if (lines[0] == "1") //it's night
        {
            Destroy(gameObject, 0.0f);
        }
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
        // init timer
        lastSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float timeSinceLastSpawn = Time.time - lastSpawnTime;
        // this formula creates a linear function from maxSunSpawnTime=0% to maxSunSpawnTime=100%
        float currentProbability = 100 * (timeSinceLastSpawn - minSunSpawnTime) / (maxSunSpawnTime - minSunSpawnTime);
        float random = Random.Range(0.0f, 100.0f);
        // don't spawn before "minSunSpawnTime" seconds && latest after "maxSunSpawnTime" seconds
        if (timeSinceLastSpawn > minSunSpawnTime && random < currentProbability)
        {
            lastSpawnTime = Time.time;
            //Debug.Log(random + " < " + currentProbability);
            int cellMin = Mathf.Min(Random.Range(0, 5), 4);
            int cellMax = Mathf.Min(Random.Range(0, 9), 8);
            //Debug.Log("cellMin: " + cellMin + "; CellMax: " + cellMax + "; Value: " + cells[cellMin, cellMax]);

            GameObject newSun = (GameObject) Instantiate(sun, cells[cellMin, cellMax], transform.rotation, transform);
        }
    }
}
