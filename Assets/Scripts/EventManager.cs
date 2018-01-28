using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

	public delegate void Tranmission();
	public static event Tranmission TransmissionEvent;

	public static void CompleteTransmission()
	{
		TransmissionEvent();
	}

}
