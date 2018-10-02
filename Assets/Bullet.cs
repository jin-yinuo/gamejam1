using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Rigidbody2D rb;

    public float moveSpeed = 50;
    public float moveDir = -1; //-1 is left and 1 is right
    public float v; //bullet's horizontal velocity

    Transform tf;

    public double left = -8.75; //screen dimensions
    public double right = 8.75;


    private void Awake()
    {
        v = moveDir * moveSpeed;
        tf = GetComponent<Transform>();


        
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(v, 0);
    }

    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// void Update() destroys the gameObject if it exits the screen
	void Update () {
        if (tf.position.x > right || tf.position.x < left)
        {
            Destroy(this.gameObject);
        }
    }

    // void OnCollisionEnter2D(Collision2D coll) determines what happens when the bullet collides with other gameObjects.
    // If the bullet collides with an enemy, both the enemy and the bullet are destroyed
    // Collisions are ignored if the bullet collides with a platform.
    void OnCollisionEnter2D(Collision2D coll)
    { 
        if (coll.gameObject.name == "Enemy(Clone)")
        { 
            Debug.Log("Hit enemy"); 
            Destroy(coll.gameObject); 
            Destroy(this.gameObject); 
        }
        if (coll.gameObject.name.StartsWith ("Basic_Platform")) {
            Physics2D.IgnoreCollision(coll.transform.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
    }

    
}
