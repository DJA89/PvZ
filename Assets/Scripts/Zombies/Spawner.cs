using System;
using UnityEngine;


public class Spawner : MonoBehaviour
{

    public GameObject zombie1;
    public GameObject zombie2;
    public GameObject zombie3;

    public Vector3 firstCell;
    public GameObject[] lanes;

    private Vector3[] cells;
    private float[][] level;
    private int currentLine;
    private GameObject[] zombies;
    private float levelStartTime;

    public AudioClip zombiesAreComingSound;
    private bool zombiesAreComing = false;
    private bool firstZombieSpawned = false;
    float RELATIVE_SFX_VOLUME = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        lanes = new GameObject[5];

        for (int k = 0; k < 5; k++)
        {
            GameObject newLane = new GameObject("Lane");
            newLane.transform.parent = transform;
            lanes[k] = newLane;

        }

        levelStartTime = Time.time;
        Vector3 cellDiff = new Vector3(0, 0, 3f);
        cells = new Vector3[5];
        cells[0] = firstCell; // new Vector3(-8f, -2f, -2f);
        zombies = new GameObject[3];
        zombies[0] = zombie1;
        zombies[1] = zombie2;
        zombies[2] = zombie3;
        //Se puede agregar un zombie con cabeza de planta que dispare

        int i;
        for (i = 1; i < 5; i++)
        {
            cells[i] = cells[i - 1] + cellDiff;
        }
        TextAsset levelFile = Globals.Instance.currentLevelFile;
        string[] lines = levelFile.ToString().Trim().Split(new string[] { "\n", "\r\n" }, StringSplitOptions.None);
        level = new float[lines.Length - 1][];

        i = -2;
        int j;

        foreach (string line in lines)
        {
            i++;
            if (i == -1) // first line
            {
                Globals.Instance.isDay = true;
                if (line.Trim() == "1") //it's night
                {
                    Globals.Instance.isDay = false;
                }
                continue;
            }
            level[i] = new float[6];
            j = 0;
            foreach (string data in line.Split(','))
            {
                level[i][j] = float.Parse(data.Trim(), System.Globalization.CultureInfo.InvariantCulture);
                // if zombie
                if (j > 0 && level[i][j] > 0)
                {
                    Globals.Instance.zombiesLeftInLevel++;
                }
                j++;
            }
        }
        currentLine = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time - levelStartTime;

        // before first zombie
        if (!zombiesAreComing && currentTime >= level[currentLine][0] - 4)
        {
            // "the zombies are coming"
            AudioSource.PlayClipAtPoint(zombiesAreComingSound, Camera.main.transform.position, Globals.Instance.sfxVolume * RELATIVE_SFX_VOLUME);
            zombiesAreComing = true;
        }

        if (currentLine < level.Length && currentTime >= level[currentLine][0])
        {
            int currentZombie;
            for (int j = 1; j < 6; j++)
            {
                currentZombie = (int) level[currentLine][j] - 1;
                if (level[currentLine][j] != 0)
                {
                    GameObject newZombie = (GameObject) Instantiate(zombies[currentZombie], cells[j-1], transform.rotation, transform);
                    if (level[currentLine][j] == 3) // rotate peashooter because it is broken
                    {
                        newZombie.transform.Rotate(new Vector3(0, 90, 0));
                    }
                    newZombie.transform.parent = lanes[j-1].transform;
                    // on first zombie
                    if (!firstZombieSpawned)
                    {
                        // start playing zombie groans
                        GetComponent<ZombieGroans>().zombiesComing = true;
                        firstZombieSpawned = true;
                    }
                }
            }
            currentLine++;
        }

    }

}
