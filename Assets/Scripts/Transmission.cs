using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transmission : MonoBehaviour {

    private string receivedMessage;
    public InstructionList codebook;
    public GameObject friendlyBeacon;

    private float lightTimerMax = 0.25f;
    private float lightTimer;

	// Use this for initialization
	void Start () {
        lightTimer = lightTimerMax;
	}
	
	// Update is called once per frame
	void Update () {
	    lightTimer -= Time.deltaTime;
		if (lightTimer <= 0.0f)
		{
			if (friendlyBeacon.GetComponent<MeshRenderer>().material.color == Color.white)
				friendlyBeacon.GetComponent<MeshRenderer>().material.color = Color.magenta;
			else
				friendlyBeacon.GetComponent<MeshRenderer>().material.color = Color.white;
			lightTimer = lightTimerMax;
		}
	}

    // friendly ship receives a message from player - goes to validate it
    public void receiveTransmission(string message)
    {
        receivedMessage = message;
        validateMessage(receivedMessage);
    }

    // friendly ship validates code. If valid, takes action
    private void validateMessage(string message)
    {
        bool isValid = false;
        string actionToTake = "";
        foreach (Instruction i in codebook.instructionList)
        {
            if (message == i.code)
            {
                isValid = true;
                actionToTake = i.action;
                Debug.Log("Received valid code: " + message);
            }
        }
        if (isValid)
            takeAction(actionToTake);
        else
        {
            Debug.Log("ERROR: invalid code!");
        }

    }

    // friendly ship takes action 
    private void takeAction(string message)
    {
        Debug.Log("Performing action: " + message);
    }

}
