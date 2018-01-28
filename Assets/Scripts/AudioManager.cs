using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    [SerializeField] public List<AudioClip> levelMusic;
    public AudioSource currentMusic;

	// Use this for initialization
	void Start () {
        updateMusic(0);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void updateMusic(int level)
    {
        currentMusic.Stop();
        currentMusic.clip = levelMusic[level];
        currentMusic.Play();
    }
}
