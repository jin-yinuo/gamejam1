using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    static int num_enemies = 0;
    float moveSpeed = 2f;
    System.Random r = new System.Random();
    Rigidbody2D rb;
    int dirTime = 100;
    float i = 1f;

    public Level level;
    Transform tf;

    public double bottom = -5.34;

    // Use this for initialization
    private void Awake()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        num_enemies++;
    }

    // Update is called once per frame
    void Update()
    {
        if ((this.transform.position.x < -8.4) || (this.transform.position.x > 8.4) ||
            (this.transform.position.y < -4.4) || (this.transform.position.y > 4.4))
        {
            num_enemies--;
        }
        Move();

        if (tf.position.y < bottom)
        {
            --Level.numEnemies;
            Destroy(this.gameObject);
        }
    }

    void Move()
    {
        Vector3 playerPos = GameObject.Find("Player").transform.position;
        if ((playerPos.y - transform.position.y < 0.5) && (playerPos.y - transform.position.y > -0.5))
        {
            FollowPlayer();
        }
        else
        {
            MoveAround();
        }
    }

    void FollowPlayer()
    {
        Vector3 playerPos = GameObject.Find("Player").transform.position;
        if (playerPos.x - transform.position.x > 0)
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        else
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    void MoveAround()
    {
        if (i == 0)
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        else
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        if (dirTime < 0)
        {
            i = r.Next(0, 2);
            dirTime = r.Next(30, 150);
        }
        else
            dirTime--;

    }

    public int getNumEnemies()
    {
        return num_enemies;
    }
}
