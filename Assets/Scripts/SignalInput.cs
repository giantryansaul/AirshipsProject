using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignalInput : MonoBehaviour {

    //private Controls.cameraview curcamera;
    public Image signalOutput;
    public Button sigButtonUp;
    public Button sigButtonDown;
    public Button sigButtonLeft;
    public Button sigButtonRight;
    public Button sigButtonSend;
    public Transmission friendlyship;

    private string messageBuffer;

	// Use this for initialization
	void Start () {
        //curcamera = GameObject.Find("MainController").GetComponent<Controls>().currentCamera;
        messageBuffer = "";
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("MainController").GetComponent<Controls>().currentCamera == Controls.cameraview.starboard)
        {
            if (Input.GetKeyDown(KeyCode.W))
               sigButtonUp.GetComponent<Button>().onClick.Invoke();
            if (Input.GetKeyDown(KeyCode.A))
                sigButtonLeft.GetComponent<Button>().onClick.Invoke();
            if (Input.GetKeyDown(KeyCode.D))
                sigButtonRight.GetComponent<Button>().onClick.Invoke();
            if (Input.GetKeyDown(KeyCode.S))
                sigButtonDown.GetComponent<Button>().onClick.Invoke();
            if (Input.GetKeyDown(KeyCode.R))
                sigButtonSend.GetComponent<Button>().onClick.Invoke();
        }	
	}

    public void signalUp()
    {
        Debug.Log("Up");
        messageBuffer += "U";
        signalOutput.color = Color.yellow;
    }

    public void signalDown()
    {
        Debug.Log("Down");
        messageBuffer += "D";
        signalOutput.color = Color.green;
    }

    public void signalLeft()
    {
        Debug.Log("Left");
        messageBuffer += "L";
        signalOutput.color = Color.blue;
    }

    public void signalRight()
    {
        Debug.Log("Right");
        messageBuffer += "R";
        signalOutput.color = Color.red;
    }

    public void signalSend()
    {
        Debug.Log("Send Message: " + messageBuffer);
        friendlyship.receiveTransmission(messageBuffer);
        clearBuffer();
    }

    public void clearBuffer()
    {
        messageBuffer = "";
        signalOutput.color = Color.white;
    }
}
