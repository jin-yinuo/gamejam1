using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    static int num_enemies = 0; //current number of enemies
    float moveSpeed = 2f; 
    System.Random r = new System.Random();
    Rigidbody2D rb;
    int dirTime = 100; //time before the enemy changes direction for the first time
    float i = 1f;
    public double leftEdge = -8.75; //screen dimensions
    public double rightEddge = 8.75;
    public double bottom = -5.34;

    public Level level;
    Transform tf;

    private void Awake()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        num_enemies++;
    }

    //void Update() keeps track of the number of enemies per frame and calls Move() to allow the enemies to move every frame. 
    //It also allows the enemeis to appear on the left side of the screen if they exit on the right and vice versa.
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

        Vector3 p = tf.position;
        Vector3 p2 = p;
        p2.x = p2.x * -1;
        if (p.x > rightEddge || p.x < leftEdge)
        {
            tf.position = p2;
        }
    }

    //void Move() allows enemies to follow the player if they are on the same platform level or to just move around randomly otherwise
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

    //void FollowPlayer() allows the enemies to follow the player if the enemy and the player are on the same platform level
    void FollowPlayer()
    {
        Vector3 playerPos = GameObject.Find("Player").transform.position;
        if (playerPos.x - transform.position.x > 0)
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        else
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    //void MoveAround() allows the enemies to move around at random
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

    //int getNumEnemies() returns the number of enemies currently on the screen
    public int getNumEnemies()
    {
        return num_enemies;
    }

    //void OnCollisionEnter2D(Collision2D coll) determines what happens when an enemy collides with other gameObjects.
    //Collisions are ignored when colliding with another enemy or ammo.
    void OnCollisionEnter2D(Collision2D coll)
    { 
        if (coll.gameObject.name.StartsWith("Enemy") || coll.gameObject.name.StartsWith("Ammo"))
        {
            Physics2D.IgnoreCollision(coll.transform.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
    }
}
