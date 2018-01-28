using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

	public GameObject closeCloudsPrefab;
	public GameObject middleCloudsPrefab;
	public GameObject farCloudsPrefab;

	private int numCloseClouds = 0;
	private int numMidClouds = 0;
	private int numFarClouds = 0;

	private float timeTracker;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		timeTracker += Time.deltaTime;

		if (timeTracker / 5 > numCloseClouds)
		{
			Instantiate(closeCloudsPrefab);
			numCloseClouds++;
		}

		if (timeTracker / 10 > numMidClouds)
		{
			Instantiate(middleCloudsPrefab);
			numMidClouds++;
		}
		
		if (timeTracker / 20 > numFarClouds)
		{
			Instantiate(farCloudsPrefab);
			numFarClouds++;
		}
	}
}
