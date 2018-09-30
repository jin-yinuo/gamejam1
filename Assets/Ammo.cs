using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ammo : MonoBehaviour
{
    public Transform a;
    GameObject clone;
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
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Enemy(Clone)") {
            Physics2D.IgnoreCollision(collision.transform.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
