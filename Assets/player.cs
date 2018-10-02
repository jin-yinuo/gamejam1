using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float jumpForce = 500.0f; //Base force for a jump
    public float speed = 30.0f; //Speed of the player
    public double leftEdge = -8.75; //Screen dimensions
    public double rightEddge = 8.75;
    public double bottom = -5.34;

    System.Random r = new System.Random();
    public float x;

    public int numAmmo = 10;
    bool isGrounded = true;

    int num_lives = 3;
    bool paused = false;

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

    void Start()
    {
        AmmoText.numAmmo = numAmmo;
    }

    //void Update() is executed every frame and waits for user to give input or for the player to reach the bottom of the screen
    void Update()
    {
        MoveHorizontal(Input.GetAxis("Horizontal")); //Move/adjust our horizontal velocity based on our horizontal input
        if (Input.GetButtonDown("Jump")) //true if SPACEBAR is pressed by user
        {
            Jump();
        }

        if (Input.GetButtonDown("Fire1")) //true if CTRL is pressed by user
        {
            Shoot();
        }

        Vector3 currVel = rb.velocity;
        GetComponent<SpriteRenderer>().flipX = currVel.x > 0; //character is flipped if true

        if (tf.position.y < bottom) //gameover if player reaches the bottom of the screen
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    //void MoveHorizontal(float input) takes a float input from -1.0 to 1.0 and allows player to move right and left
    void MoveHorizontal(float input)
    { 
        Vector2 moveVel = rb.velocity; //Get our current rigidbody's velocity
        moveVel.x = input * speed * Time.deltaTime; //Set the new x velocity to be the given input times our speed
                                               
        rb.velocity = moveVel; //Update our rigidbody's velocity

        Vector3 p = tf.position;
        Vector3 p2 = p;
        p2.x = p2.x * -1;
        if (p.x > rightEddge || p.x < leftEdge) //allows the player to appear on the other side of screen 
        {
            tf.position = p2;
        }
    }

    //void Jump() allows the player to jump if they are grounded on a platform
    void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce); //Add a upward force to our rigidbody
        }
    }

    //void Shoot() allows the player to shoot when they have ammo available
    void Shoot()
    {
        if (numAmmo > 0)
        {
            if (GetComponent<SpriteRenderer>().flipX) //decides on the direction of the bullet based on which way the player is facing
                bullet.moveDir = 1;
            else
                bullet.moveDir = -1;
            Vector3 currPos = tf.position;
            Vector3 currVel = rb.velocity;
            Instantiate(bullet, currPos, Quaternion.identity); //launches the bullet
            numAmmo--;
            AmmoText.numAmmo = numAmmo; //updates ammo text in the background
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision) controls what happens when the player collides with other gameObjects
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.name.StartsWith("Basic_Platform"))&&(transform.position.y - collision.transform.position.y > 0.8f)) { //only allows the player to jump if they are on the platform
            isGrounded = true;
            Debug.Log(isGrounded);
        }
        if ((collision.gameObject.name == "Ammo") || (collision.gameObject.name == "Ammo (1)") || (collision.gameObject.name == "Ammo(Clone)")) //increases ammo count when player collides with ammo
        {
            numAmmo++;
            AmmoText.numAmmo = numAmmo;
            Destroy(collision.gameObject);
        } else if (collision.gameObject.name.StartsWith("Enemy")&&!paused)  //decreases lives when player collides with enemy
        {
            if (Lives.lives > 1)
                Lives.lives--;
            else
                SceneManager.LoadScene("GameOver");
            StartCoroutine(PauseCollision(2));
            paused = true;
        }
    }

    //IEnumerator PauseCollision(float time) pauses the player's collision effects with enemy for time (seconds)
    IEnumerator PauseCollision(float time)
    {
        yield return new WaitForSeconds(time);
        paused = false;
    }

    //private void OnCollisionExit2D(Collision2D collision) prevents the player from jumping while in midair
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("Basic_Platform")) {
            isGrounded = false;
            Debug.Log(isGrounded);
        }
    }
}