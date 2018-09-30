﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float jumpForce = 500.0f; //Base force for a jump
    public float speed = 30.0f; //Speed of the player
    public double leftEdge = -8.75;
    public double rightEddge = 8.75;

    //public float top = 4F;
    //public int screenLeft = -12;
    //public int screenRight = 1;
    //public float dropTime = 7f;
    System.Random r = new System.Random();
    public float x;
  

    //MonoBehaviour object components
    public Transform platformLeft;
    public Transform platformRight;

    public Bullet bullet;

    Transform tf;
    Rigidbody2D rb;
    CircleCollider2D cc;
    SpriteRenderer sr;

    void Awake()
    {
        //Get references to our components
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CircleCollider2D>();
    }

    // Use this for initialization
    void Start()
    {
        //InvokeRepeating("Drop", dropTime, dropTime);
    }


    // Update is called once per frame
    void Update()
    {
        MoveHorizontal(Input.GetAxis("Horizontal")); //Move/adjust our horizontal velocity based on our horizontal input
        if (Input.GetButtonDown("Jump"))
        { //If we pushed the jump button down this frame...
            Jump(); //Lets jump!
        }

        if (Input.GetButtonDown("Fire1"))
        { //If we pushed the jump button down this frame...
            Shoot(); //Lets jump!
        }
    }

    void MoveHorizontal(float input)
    { //Takes a input from -1.0 to 1.0
        Vector2 moveVel = rb.velocity; //Get our current rigidbody's velocity
        moveVel.x = input * speed * Time.deltaTime; //Set the new x velocity to be the given input times our speed
                                                    //Note the multiply by Time.deltaTime to compensate for game clock

        rb.velocity = moveVel; //Update our rigidbody's velocity

        rb.velocity = moveVel; //Update our rigidbody's velocity

        Vector3 p = tf.position;
        Vector3 p2 = p;
        p2.x = p2.x * -1;
        if (p.x > rightEddge || p.x < leftEdge)
        {
            tf.position = p2;
        }
    }

    void Jump()
    {
        //Replace "true" with "IsGrounded()" if you want to stop the infinite jumps
        if (true)
        {
            rb.AddForce(Vector2.up * jumpForce); //Add a upward force to our rigidbody
        }
    }

    void Shoot()
    {
        Vector3 currPos = tf.position;
        Vector3 currVel = rb.velocity;
        Instantiate(bullet, currPos, Quaternion.identity);
        bullet.moveDir = (currVel.x > 0) ? 1 : -1;
      

    }

    //void Drop()
    //{
      //  x = r.Next(screenLeft, screenRight);
       // Instantiate(platformLeft, new Vector3(x, top, 0), Quaternion.identity);
       // Instantiate(platformRight, new Vector3(x + 16, top, 0), Quaternion.identity);

    //}

    //bool IsGrounded()
    //{/

    //}

}