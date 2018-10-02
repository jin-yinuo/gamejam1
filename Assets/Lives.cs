using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public static int lives = 3; //number of total lives
    public Transform heart3;
    public Transform heart2;

    void Start()
    {
        lives = 3; //resets number of hearts to 3 everytime the game starts
    }

    // void Update() is called once per frame and keeps track of how many hearts to display on the screen
    void Update()
    {
        if (lives == 2)
        {
            heart3.gameObject.SetActive(false);
        } else if (lives == 1)
        {
            heart2.gameObject.SetActive(false);
        }
    }
}
