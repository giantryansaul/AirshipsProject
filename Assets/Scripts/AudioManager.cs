using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    [SerializeField] public List<AudioClip> levelMusic;
    public AudioSource currentMusic;

    [SerializeField] public List<AudioClip> successSFX;
    [SerializeField] public List<AudioClip> errorSFX;
    [SerializeField] public List<AudioClip> impactSFX;
    public AudioSource currentSFX;

    public AudioSource starboardAmbient;
    public AudioSource bowAmbient;

    // Use this for initialization
    void Start () {
        updateMusic(0);
        changeRoomAmbient(Controls.cameraview.starboard);

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

    public void changeRoomAmbient(Controls.cameraview room)
    {
        if (room == Controls.cameraview.starboard)
        {
            bowAmbient.Stop();
            starboardAmbient.Play();
        }
        else
        {
            starboardAmbient.Stop();
            bowAmbient.Play();
        }
    }

    public void playErrorSFX()
    {
        int rnd = Random.Range(0, errorSFX.Count);
        currentSFX.clip = errorSFX[rnd];
        currentSFX.PlayOneShot(errorSFX[rnd]);
    }

    public void playSuccessSFX()
    {
        int rnd = Random.Range(0, successSFX.Count);
        currentSFX.clip = successSFX[rnd];
        currentSFX.PlayOneShot(successSFX[rnd]);
    }

    public void playImpactSFX()
    {
        int rnd = Random.Range(0, impactSFX.Count);
        currentSFX.clip = impactSFX[rnd];
        currentSFX.PlayOneShot(impactSFX[rnd]);
    }
}
