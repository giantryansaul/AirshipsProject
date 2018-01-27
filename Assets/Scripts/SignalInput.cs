using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignalInput : MonoBehaviour {

    //private Controls.cameraview curcamera;
    public Image signalOutput;

	// Use this for initialization
	void Start () {
        //curcamera = GameObject.Find("MainController").GetComponent<Controls>().currentCamera;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("MainController").GetComponent<Controls>().currentCamera == Controls.cameraview.starboard)
        {
            if (Input.GetKeyDown(KeyCode.W))
                this.transform.Find("SignalButtonUp").GetComponent<Button>().onClick.Invoke();
            if (Input.GetKeyDown(KeyCode.A))
                this.transform.Find("SignalButtonLeft").GetComponent<Button>().onClick.Invoke();
            if (Input.GetKeyDown(KeyCode.D))
                this.transform.Find("SignalButtonRight").GetComponent<Button>().onClick.Invoke();
            if (Input.GetKeyDown(KeyCode.S))
                this.transform.Find("SignalButtonDown").GetComponent<Button>().onClick.Invoke();
            if (Input.GetKeyDown(KeyCode.R))
                this.transform.Find("SignalButtonSend").GetComponent<Button>().onClick.Invoke();
        }	
	}

    public void signalUp()
    {
        Debug.Log("Up");
        signalOutput.color = Color.yellow;
    }

    public void signalDown()
    {
        Debug.Log("Down");
        signalOutput.color = Color.green;
    }

    public void signalLeft()
    {
        Debug.Log("Left");
        signalOutput.color = Color.blue;
    }

    public void signalRight()
    {
        Debug.Log("Right");
        signalOutput.color = Color.red;
    }

    public void signalSend()
    {
        Debug.Log("Send Message: ");
    }

}
