using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewSwitch : MonoBehaviour {
	
	public Camera StarboardCamera;
    public Canvas StarboardCanvas;
	public Canvas StarboardBackgroundCanvas;
	public Canvas StarboardMiddleCanvas;
	public Canvas StarboardFrontCanvas;
	public Camera BowCamera;
    public Canvas BowCanvas;

    private Controls.cameraview curcamera;

	public void ShowStarboardCamera() 
	{
		SwitchBow(false);
		SwitchStarboard(true);
        curcamera = Controls.cameraview.starboard;
	}
    
	public void ShowBowCamera()
	{
		SwitchBow(true);
		SwitchStarboard(false);
        curcamera = Controls.cameraview.bow;
    }

	private void SwitchStarboard(bool status)
	{
		StarboardCamera.enabled = status;
		StarboardCanvas.enabled = status;
		StarboardBackgroundCanvas.enabled = status;
		StarboardMiddleCanvas.enabled = status;
		StarboardFrontCanvas.enabled = status;
	}

	private void SwitchBow(bool status)
	{
		BowCamera.enabled = status;
		BowCanvas.enabled = status;
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
        GameObject.Find("AudioManager").GetComponent<AudioManager>().changeRoomAmbient(curcamera);
    }

	void Start () {
        curcamera = GameObject.Find("MainController").GetComponent<Controls>().currentCamera;
		ShowStarboardCamera();
	}
}
