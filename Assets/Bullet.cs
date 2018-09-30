using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Rigidbody2D rb;

    public float moveSpeed = 50;
    public float moveDir = 1;
    public float v;

    Transform tf;

    public double left = -8.75;
    public double right = 8.75;


    private void Awake()
    {
        v = moveDir * moveSpeed;
        tf = GetComponent<Transform>();


        
        rb = GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector2(50, 0);
    }

    // Use this for initialization
    void Start () {
        float v = moveDir * moveSpeed;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(v, 0);
    }
	
	// Update is called once per frame
	void Update () {
        //Vector2 moveVel = rb.velocity; //Get our current rigidbody's velocity
        //moveVel.x = input * speed * Time.deltaTime; //Set the new x velocity to be the given input times our speed
        //Note the multiply by Time.deltaTime to compensate for game clock
        //rb.velocity = moveVel;

        if (tf.position.x > right || tf.position.x < left)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    { //On the frame this object's Collider collides with another collider...
        if (coll.gameObject.name == "Enemy(Clone)")
        {  //Check if we've hit a speed powerup
            Debug.Log("Hit enemy"); //Lets let the console know we've hit a powerup
            Destroy(coll.gameObject); //Destroy the enemy 
            Destroy(this.gameObject); 
        }
    }
}
