using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{ 
    public enum cameraview
    {
        starboard,
        bow
    }

    public cameraview currentCamera;

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			gameObject.GetComponent<ViewSwitch>().ChangeCamera();
            GameObject.Find("SignalPanel").GetComponent<SignalInput>().clearBuffer();
		}
	}
}
