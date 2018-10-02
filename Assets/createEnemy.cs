using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


//This is an empty class for now. All variables and functions are moved to the Level class for better management and functionalities.

public class createEnemy : MonoBehaviour
{
    public Transform enemy;
    public GameObject clone;
    int init_num = 1; //initial number of enemies
    int max_num = 3; //maximum number of enemies
    int dim_x = 8; //screen dimensions
    int dim_y = 4; //screen dimensions
    System.Random r = new System.Random();
    float x;
    float y;
    public int maxSpawnTime = 10; //number of seconds

    void Start()
    {
    }

    void RandomSpawn()
    {
        float randomTime = r.Next(0, maxSpawnTime * 1000) / 1000;
    }

    void Update()
    {
    }
}