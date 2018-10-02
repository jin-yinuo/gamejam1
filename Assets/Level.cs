using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    public float dropTime = 6f;
    public float top = 4F;
    public int screenLeft = -12;
    public int screenRight = 1;
    public Transform platformLeft;
    public Transform platformRight;
    public int distance = 14;
    float prevPlatform;

    public Transform ammo;
    public Enemy enemy;
    public GameObject clone;
    int init_num = 1; //initial number of enemies on the screen
    public static int numEnemies; //current number of enemies on the screen
    int max_num = 6; //maximum number of enemies on the screen
    int dim_x = 8; //screen dimensions
    int dim_y = 4; //screen dimensions
    System.Random r = new System.Random();
    float x;
    float y;
    public int maxSpawnTime = 5; //number of seconds enemies are spawned

    void Start () {
        InvokeRepeating("Drop", 2F, dropTime); //generates new platforms every 2 seconds
        InvokeRepeating("CreateAmmo", dropTime, dropTime); //creates ammo within dropTime intervals

        for (int i = 0; i < init_num; i++) //creates the first init_num enemies at the start of the game
        {
            x = r.Next(-dim_x * 1000, dim_x * 1000) / 1000f;
            y = r.Next(0, dim_y * 1000) / 1000f;
            Instantiate(enemy, new Vector3(x, y, 0), Quaternion.identity);
            ++numEnemies;
        }
        Invoke("RandomSpawn", r.Next(0, maxSpawnTime * 1000) / 1000); //generates new enemies in intervals
    }
    
    //void RandomSpawn() spawns new enemies every maxSpawnTime if the number of current enemies on the screen is below the maximum number of enemies
    void RandomSpawn()
    {
        float randomTime = r.Next(0, maxSpawnTime * 1000) / 1000;
        if (numEnemies < max_num)
        {
            x = r.Next(-dim_x * 1000, dim_x * 1000) / 1000f;
            Instantiate(enemy, new Vector3(x, 6, 0), Quaternion.identity);
        }
        else
        {
            return;
        }
        Invoke("RandomSpawn", randomTime);
    }

    void Update () {
		
	}

    //void Drop() generates new left and right platforms at the top of the screen. The positions of the platforms are random with a set distance apart.
    void Drop()
    {
        x = r.Next(screenLeft, screenRight);
        while (x == prevPlatform)
        {
            x = r.Next(screenLeft, screenRight);
        }
        Instantiate(platformLeft, new Vector3(x, top, 0), Quaternion.identity);
        Instantiate(platformRight, new Vector3(x + distance, top, 0), Quaternion.identity);
        prevPlatform = x;

    }
    
    //void CreateAmmo() creates ammo at the top of the screen with a random x-coordinate.
    void CreateAmmo()
    {
        x = r.Next(-8 * 1000, 8 * 1000) / 1000f;
        Instantiate(ammo, new Vector3(x, top+1, 0), Quaternion.identity);
    }
}
