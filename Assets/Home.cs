using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Home : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {

    }

    public void NextScene()
    {
        SceneManager.LoadScene("pretty");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
