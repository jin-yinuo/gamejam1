using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public int numAmmo = 10;
    bool isGrounded = true;

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
        AmmoText.numAmmo = numAmmo;
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

        Vector3 currVel = rb.velocity;
        GetComponent<SpriteRenderer>().flipX = currVel.x > 0;
 
    }

    void MoveHorizontal(float input)
    { //Takes a input from -1.0 to 1.0
        Vector2 moveVel = rb.velocity; //Get our current rigidbody's velocity
        moveVel.x = input * speed * Time.deltaTime; //Set the new x velocity to be the given input times our speed
                                                    //Note the multiply by Time.deltaTime to compensate for game clock

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
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce); //Add a upward force to our rigidbody
        }
    }

    void Shoot()
    {
        if (numAmmo > 0)
        {
            Vector3 currPos = tf.position;
            Vector3 currVel = rb.velocity;
            Instantiate(bullet, currPos, Quaternion.identity);
            bullet.moveDir = (currVel.x > 0) ? 1 : -1;
            numAmmo--;
            AmmoText.numAmmo = numAmmo;
        }
    }

    //void Drop()
    //{
    //  x = r.Next(screenLeft, screenRight);
    // Instantiate(platformLeft, new Vector3(x, top, 0), Quaternion.identity);
    // Instantiate(platformRight, new Vector3(x + 16, top, 0), Quaternion.identity);

    //}

   // bool IsGrounded()
    //{
    //    float DistanceToTheGround = GetComponent<BoxCollider2D>().bounds.extents.y;

    //    bool grounded = Physics.Raycast(transform.position, Vector3.down, DistanceToTheGround + 10f);
    //    return grounded;
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("Basic_Platform")) {
            isGrounded = true;
        }
        if ((collision.gameObject.name == "Ammo") || (collision.gameObject.name == "Ammo (1)") || (collision.gameObject.name == "Ammo(Clone)"))
        {
            numAmmo++;
            AmmoText.numAmmo = numAmmo;
            Destroy(collision.gameObject);
        } else if (collision.gameObject.name.StartsWith("Enemy")) 
        {
            //Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("Basic_Platform")) {
            isGrounded = false;
        }
    }
}