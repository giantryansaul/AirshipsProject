using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewSwitch : MonoBehaviour {
	
	public Camera StarboardCamera;
    public Canvas StarboardCanvas;
	public Canvas StarboardBackgroundCanvas;
	public Camera BowCamera;
    public Canvas BowCanvas;

    private Controls.cameraview curcamera;

	public void ShowStarboardCamera() {
		BowCamera.enabled = false;
        BowCanvas.enabled = false;
		StarboardCamera.enabled = true;
        StarboardCanvas.enabled = true;
		StarboardBackgroundCanvas.enabled = true;
        curcamera = Controls.cameraview.starboard;
	}
    
	public void ShowBowCamera() {
		BowCamera.enabled = true;
        BowCanvas.enabled = true;
		StarboardCamera.enabled = false;
        StarboardCanvas.enabled = false;
		StarboardBackgroundCanvas.enabled = false;
        curcamera = Controls.cameraview.bow;
    }

	public void ChangeCamera()
	{
		if (BowCamera.enabled)
		{
			ShowStarboardCamera();
		}
		else
		{
			ShowBowCamera();
		}
        GameObject.Find("MainController").GetComponent<Controls>().currentCamera = curcamera;
    }

	void Start () {
        curcamera = GameObject.Find("MainController").GetComponent<Controls>().currentCamera;
		ShowStarboardCamera();
	}
}
