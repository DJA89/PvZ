using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject zombie;

    private float timeSinceLastZombie;
    public Vector3 firstCell;
    public float maxTimeBetweenZombies;
    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastZombie = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cellDiff = new Vector3(0, 0, 3f);
        Vector3[] cells = new Vector3[5];
        cells[0] = firstCell; // new Vector3(-8f, -2f, -2f);
        for(int i = 1; i < 5; i++)
        {
            cells[i] = cells[i-1] + cellDiff;
        }


        timeSinceLastZombie += Time.deltaTime;
        float probability = Mathf.Min(timeSinceLastZombie / maxTimeBetweenZombies, 1);
        if (Random.Range(0.0f, 1.0f) < probability)
        {
            GameObject obj = (GameObject) Instantiate(zombie, cells[Mathf.Min(Random.Range(0, 5), 4)], transform.rotation);
            obj.transform.parent = transform;
            timeSinceLastZombie = 0.0f;
        }

    }
}
