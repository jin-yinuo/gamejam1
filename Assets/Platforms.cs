using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Platforms : MonoBehaviour {

    Transform tf;

    public double bottom = -5.34; //bottom screen dimension

    void Awake()
    {
        tf = GetComponent<Transform>();
    }

    void Start () {
    }
	
	// void Update() is called once per frame and destroys this gameObject if it reaches the bottom of the screen
	void Update () {
        if (tf.position.y < bottom-2)
        {
            Destroy(this.gameObject);
        }
	}

}
