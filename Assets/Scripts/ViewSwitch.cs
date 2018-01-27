using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewSwitch : MonoBehaviour {
	
	public Camera StarboardCamera;
	public Camera BowCamera;

	public void ShowStarboardCamera() {
		BowCamera.enabled = false;
		StarboardCamera.enabled = true;
	}
    
	public void ShowBowCamera() {
		BowCamera.enabled = true;
		StarboardCamera.enabled = false;
	}

	void Start () {
		ShowStarboardCamera();
	}
}
