using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEnemy : MonoBehaviour
{
	private ObjectMovement movement;
	public int DestoryRangeZ = -40;
	
	// Use this for initialization
	void Start ()
	{
		var startPosition = StartPositionGenerator.GenerateFloatingEnemyStartPosition();
		gameObject.transform.position = startPosition;
		movement = new ObjectMovement(0, 0, -2, startPosition);
	}
	
	// Update is called once per frame
	void Update ()
	{
		gameObject.transform.position = movement.GetUpdatedPosition(Time.deltaTime);
		if (gameObject.transform.position.z <= DestoryRangeZ)
			Destroy(gameObject);
	}
}
