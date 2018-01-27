using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transmission : MonoBehaviour {

    private string receivedMessage;
    public InstructionList codebook;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void receiveTransmission(string message)
    {
        receivedMessage = message;
        validateMessage(receivedMessage);
    }

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
            Debug.Log("ERROR: invalid code!");

    }

    private void takeAction(string message)
    {
        Debug.Log("Performing action: " + message);
    }
}
