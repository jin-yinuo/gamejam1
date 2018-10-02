using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoText : MonoBehaviour {
    public static int numAmmo = 0;
    Text ammoText;

    void Start () {
        ammoText = GetComponent<Text>();
	}

    //void Update() runs every frame and changes the text in the background to reflect the current number of available ammo to the player
    void Update () {
        ammoText.text = "Balls: " + numAmmo;
	}
}
