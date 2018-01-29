using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transmission : MonoBehaviour {

    private string receivedMessage;
    public InstructionList codebook;
    public GameObject friendlyBeacon;

    private float lightTimerMax = 1.0f;
    private float lightTimer;

    private string broadcastDirection;
    private bool lightIsOn;
    private string lightSequence;

    public ShipMovement friendlyShip;

	// Use this for initialization
	void Start () {
        lightTimer = 0.0f;
        broadcastDirection = null;
        lightIsOn = false;
        lightSequence = "";
	}
	
	// Update is called once per frame
	void Update () {
        if (lightIsOn)
        {
            // if the sequence has run out, repeat it
            if (lightSequence == "")
                lightSequence = getLightSequence(broadcastDirection);

            lightTimer += Time.deltaTime;
            if (lightTimer >= lightTimerMax)
            {
                Debug.Log("code: " + lightSequence);
                lightTimer = 0.0f;
                setBeaconColor(lightSequence[0]);
                lightSequence = lightSequence.Substring(1, lightSequence.Length-1);

                // exit early if broadcast is error (so we only display once)
                if (lightSequence == "" && broadcastDirection == "error")
                    broadcastStop();
            }


        }
        else
        {
            lightTimer = 0.0f;
            lightSequence = "";
            setBeaconColor('W');
        }
    }

    private string getLightSequence(string signal)
    {
        string retstring = "";
        string codeToUse = "";

        if (signal == "error")
        {
            return "WWWWEWEWEW";
        }
        else
        {
            // look up the direction code we need to move in
            foreach (Instruction i in codebook.instructionList)
            {
                if (signal == i.action)
                {
                    codeToUse = i.code;
                }
            }

            // parse out the code and broadcast each color
            for (int x = 0; x < codeToUse.Length; x++)
            {
                retstring += codeToUse[x] + "W";
            }
            retstring += "WW";  // delay between sequences

            return retstring;
        }
    }

    private void setBeaconColor(char dir)
    {
        Color clr;
        switch (dir)
        {
            case 'U':
                clr = Color.yellow;
                break;
            case 'L':
                clr = Color.blue;
                break;
            case 'D':
                clr = Color.green;
                break;
            case 'R':
                clr = Color.red;
                break;
            case 'E':
                clr = Color.magenta;
                break;
            default:
                clr = Color.white;
                break;
        }
        friendlyBeacon.GetComponent<MeshRenderer>().material.color = clr;
       // StartCoroutine("pause");
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
            }
        }
        if (isValid)
        {
            takeAction(actionToTake);
            GameObject.Find("AudioManager").GetComponent<AudioManager>().playSuccessSFX();
        }
        else
        {
            Debug.Log("ERROR: invalid code!");
            GameObject.Find("AudioManager").GetComponent<AudioManager>().playErrorSFX();
            broadcastStart("error");
        }

    }

    // friendly ship takes action 
    private void takeAction(string action)
    {
        switch (action)
        {
            case "D":
                friendlyShip.MoveDown();
                break;
            case "U":
                friendlyShip.MoveUp();
                break;
            case "R":
                friendlyShip.MoveRight();
                break;
            case "L":
                friendlyShip.MoveLeft();
                break;
        }
    }

    public void broadcastStart(string direction)
    {
        broadcastDirection = direction;
        lightIsOn = true;
        if (direction == "error")
            lightTimerMax = 0.1f;
        else
            lightTimerMax = 1.0f;
    }

    public void broadcastStop()
    {
        broadcastDirection = null;
        lightIsOn = false;
    }
}
