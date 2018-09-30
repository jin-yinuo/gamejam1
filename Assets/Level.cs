﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    public float dropTime = 6f;
    public float top = 4F;
    public int screenLeft = -12;
    public int screenRight = 1;
    public Transform platformLeft;
    public Transform platformRight;

    public Transform ammo;
    public Enemy enemy;
    public GameObject clone;
    int init_num = 1;
    public static int numEnemies;
    int max_num = 6;
    int dim_x = 8; //screen dimensions
    int dim_y = 4; //screen dimensions
    System.Random r = new System.Random();
    float x;
    float y;
    public int maxSpawnTime = 10; //number of seconds
    // Use this for initialization
    void Start () {
        InvokeRepeating("Drop", 2F, dropTime);
        InvokeRepeating("CreateAmmo", dropTime, dropTime);

        for (int i = 0; i < init_num; i++)
        {
            x = r.Next(-dim_x * 1000, dim_x * 1000) / 1000f;
            y = r.Next(0, dim_y * 1000) / 1000f;
            Instantiate(enemy, new Vector3(x, y, 0), Quaternion.identity);
            ++numEnemies;
        }
        Invoke("RandomSpawn", r.Next(0, maxSpawnTime * 1000) / 1000);
    }

    void RandomSpawn()
    {
        float randomTime = r.Next(0, maxSpawnTime * 1000) / 1000;
        if (numEnemies < max_num)
        {
            x = r.Next(-dim_x * 1000, dim_x * 1000) / 1000f;
            Instantiate(enemy, new Vector3(x, 6, 0), Quaternion.identity);
        }
        else
        {
            return;
        }
        Invoke("RandomSpawn", randomTime);
    }

    // Update is called once per frame
    void Update () {
		
	}

    void Drop()
    {
        x = r.Next(screenLeft, screenRight);
        Instantiate(platformLeft, new Vector3(x, top, 0), Quaternion.identity);
        Instantiate(platformRight, new Vector3(x + 11, top, 0), Quaternion.identity);

    }

    void CreateAmmo()
    {
        x = r.Next(-8 * 1000, 8 * 1000) / 1000f;
        Instantiate(ammo, new Vector3(x, top+1, 0), Quaternion.identity);
    }
}
