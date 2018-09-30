using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Platforms : MonoBehaviour {

    Transform tf;
    //public Transform platform;

    public double bottom = -5.34;
    //public float top = 5F;
    //public int screenLeft = -12;
    //public int screenRight = 12;

    //public float dropTime = 1f;
   // System.Random r = new System.Random();
   // public float x;



    void Awake()
    {
        tf = GetComponent<Transform>();
  
        //Get references to our components
        //rb = 
        //cc = GetComponent<CircleCollider2D>();
    }



    // Use this for initialization
    void Start () {
        //x = r.Next(screenLeft, screenRight);
        //Instantiate(platform, new Vector3(x, top, 0), Quaternion.identity);
        //InvokeRepeating("Drop", dropTime, dropTime);
    }
	
	// Update is called once per frame
	void Update () {

  
           // Vector3 p = tf.position;
        if (tf.position.y < bottom-2)
        {
            Destroy(this.gameObject);
        }
	}

    //void Drop()
    //{
    //    x = r.Next(screenLeft, screenRight);
     //   Instantiate(platform, new Vector3(x, top, 0), Quaternion.identity);
        
    //}

}
