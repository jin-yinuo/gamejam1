using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoText : MonoBehaviour {
    public static int numAmmo = 0;
    Text ammoText;
	// Use this for initialization
	void Start () {
        ammoText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        ammoText.text = "Balls: " + numAmmo;
	}
}
