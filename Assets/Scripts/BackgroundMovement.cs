using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMovement : MonoBehaviour {

	public enum Location
	{
		Background,
		Middle,
		Foreground
	}

	private int destroySpot = -1000;
	private int createSpot = 1000;
	public int height;

	public Location space;
	
	void Start ()
	{
		height = Random.Range(-200, 200);
		
		transform.position = new Vector2(createSpot, height);
		Color color;
		switch (space)
		{
			case Location.Background:
				transform.SetParent(GameObject.Find("StarboardBackground").transform, false);
				break;
			case Location.Middle:
				transform.SetParent(GameObject.Find("StarboardMiddleCanvas").transform, false);
				break;
			case Location.Foreground:
				transform.SetParent(GameObject.Find("StarboardCloseCanvas").transform, false);
				break;
		}
		
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		var currentX = transform.localPosition.x;
		var speed = 0;
		switch (space)
		{
			case Location.Background:
				speed = 20;
				break;
			case Location.Middle:
				speed = 50;
				break;
			case Location.Foreground:
				speed = 100;
				break;
		}

		var changeX = currentX - speed * Time.deltaTime;
		transform.localPosition = new Vector2(changeX, height);
		
		if (transform.localPosition.x <= destroySpot)
			Destroy(gameObject);
	}
}
