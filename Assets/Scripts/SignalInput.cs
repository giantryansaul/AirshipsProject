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
    private float fadeTimer;

	// Use this for initialization
	void Start () {
        //curcamera = GameObject.Find("MainController").GetComponent<Controls>().currentCamera;
        messageBuffer = "";
        fadeTimer = 0.0f;
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

        if (fadeTimer > 0.0f)
        {
            fadeTimer -= Time.deltaTime;
            Color tempColor = signalOutput.color;
            tempColor.a = fadeTimer;
            signalOutput.color = tempColor;
        }
	}

    public void signalUp()
    {
        messageBuffer += "U";
        signalOutput.color = Color.yellow;
        fadeTimer = 1.0f;
    }

    public void signalDown()
    {
        messageBuffer += "D";
        signalOutput.color = Color.green;
        fadeTimer = 1.0f;
    }

    public void signalLeft()
    {
        messageBuffer += "L";
        signalOutput.color = Color.blue;
        fadeTimer = 1.0f;
    }

    public void signalRight()
    {
        messageBuffer += "R";
        signalOutput.color = Color.red;
        fadeTimer = 1.0f;
    }

    public void signalSend()
    {
        friendlyship.receiveTransmission(messageBuffer);
        clearBuffer();
    }

    public void clearBuffer()
    {
        messageBuffer = "";
        signalOutput.color = Color.white;
        fadeTimer = 1.0f;
    }
}
