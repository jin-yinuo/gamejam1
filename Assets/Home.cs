using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Home : MonoBehaviour {

    void Start ()
    {

    }

    // void NextScene() loads the pretty screen after the home screen to start the gameplay
    public void NextScene()
    {
        SceneManager.LoadScene("pretty");
    }

    void Update () {
		
	}
}
