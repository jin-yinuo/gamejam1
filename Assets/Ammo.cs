using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ammo : MonoBehaviour
{
    public Transform a;
    GameObject clone;
    int max_num = 5; // max number of spawned ammos
    int dim_x = 8; //screen dimensions
    int dim_y = 4; //screen dimensions
    System.Random r = new System.Random();
    float x;
    float y;
    public int spawnTime = 5;

    void Start()
    {
    }

    void Update()
    {

    }

    //void OnCollisionEnter2D(Collision2D collision) determines what happens when the ammo collides with other gameObjects.
    //Collisions are ignored if the ammo collides with bullets or enemies
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.name.StartsWith("Bullet")) || (collision.gameObject.name.StartsWith("Enemy"))) {
            Physics2D.IgnoreCollision(collision.transform.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
    }
}
