using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public static int lives = 3;
    public Transform heart3;
    public Transform heart2;
    // Use this for initialization
    void Start()
    {
        lives = 3;
    }

    // Update is called once per frame
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
