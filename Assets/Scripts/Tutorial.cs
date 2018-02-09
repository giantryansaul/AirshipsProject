using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{

	public string Description;

	void Start ()
	{
		gameObject.GetComponentInChildren<Text>().text = Description;
	}

	public void DestroyTutorial()
	{
		Destroy(gameObject);
		
	}
}
