using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Game Quit");
            Application.Quit();
        }
		
	}

    public void startGame()
    {
        GameObject musicObject = GameObject.Find("Music");
        if (musicObject)
            musicObject.GetComponent<AudioSource>().Stop();

        SceneManager.LoadScene(1);
    }
}
