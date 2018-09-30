using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ammo : MonoBehaviour
{
    public Transform a;
    GameObject clone;
    int init_num = 2;
    int max_num = 5;
    int dim_x = 8; //screen dimensions
    int dim_y = 4; //screen dimensions
    System.Random r = new System.Random();
    float x;
    float y;
    public int spawnTime = 5;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < init_num; i++)
        {
            x = r.Next(-dim_x * 1000, dim_x * 1000) / 1000f;
            y = r.Next(-dim_y * 1000, dim_y * 1000) / 1000f;
            Transform t = Instantiate(a, new Vector3(0, 0, 0), Quaternion.identity);
            clone = t.gameObject;
        }
        Invoke("RandomSpawn", r.Next(0, spawnTime * 1000) / 1000);
    }

    void RandomSpawn()
    {
        float randomTime = r.Next(0, spawnTime * 1000) / 1000;
        if (clone.GetComponent<Enemy>().getNumEnemies() < max_num)
        {
            x = r.Next(-dim_x * 1000, dim_x * 1000) / 1000f;
            y = r.Next(0, dim_x * 1000) / 1000f;
            Instantiate(a, new Vector3(x, y, 0), Quaternion.identity);
        }
        else
        {
            return;
        }
        Invoke("RandomSpawn", randomTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
