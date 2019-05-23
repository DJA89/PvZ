﻿using System;
using UnityEngine;


public class Spawner : MonoBehaviour
{

    public GameObject zombie1;
    public GameObject zombie2;
    public GameObject zombie3;

    public TextAsset levelFile;
    public Vector3 firstCell;
    public GameObject[] lanes;

    private Vector3[] cells;
    private int[][] level;
    private int currentLine;
    private GameObject[] zombies;
    private int levelStartFramecount;

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

        levelStartFramecount = Time.frameCount;
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
        string[] lines = levelFile.ToString().Split(new string[] { "\n", "\r\n" }, StringSplitOptions.None);
        level = new int[lines.Length][];

        i = 0;
        int j;

        foreach (string line in lines)
        {
            level[i] = new int[6];
            j = 0;
            foreach (string data in line.Split(','))
            {
                level[i][j] = System.Convert.ToInt32(data);
                j++;
            }
            i++;
        }
        currentLine = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int currentFrame = Time.frameCount - levelStartFramecount;
        if (currentLine < level.Length && level[currentLine][0] == currentFrame)
        {
            int currentZombie;
            for (int j = 1; j < 6; j++)
            {
                currentZombie = level[currentLine][j] - 1;
                if (level[currentLine][j] != 0)
                {
                    GameObject newZombie = (GameObject) Instantiate(zombies[currentZombie], cells[j-1], transform.rotation, transform);
                    if (level[currentLine][j] == 3)
                    {
                        newZombie.transform.Rotate(new Vector3(0, 90, 0));
                    }
                    newZombie.transform.parent = lanes[j-1].transform;
                }
            }
            currentLine++;
        }

    }

}
