using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
	private Vector3 TargetPosition;
	private Quaternion TargetRotation;
	private Vector3 InitialPosition;
	public Positions Position;

	void Start ()
	{
		InitialPosition = transform.position;
		MoveDown();
	}
	
	public float interpVelocity = 1.0f;
	private Vector3 targetPos;

	void Update()
	{
		SmoothMovementToTarget();
	}

	private void SmoothMovementToTarget()
	{
		var posNoZ = transform.localPosition;
		posNoZ.z = TargetPosition.z;
		var targetDirection = (TargetPosition - posNoZ);

		interpVelocity = targetDirection.magnitude * 5f;
		targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);
		transform.position = Vector3.Lerp(transform.position, targetPos, 0.1f);
	}

	public void MoveUp()
	{
		TargetPosition = InitialPosition + Vector3Positions.Up;
		Position = Positions.Up;
	}

	public void MoveLeft()
	{
		TargetPosition = InitialPosition + Vector3Positions.Left;
		Position = Positions.Left;
	}

	public void MoveRight()
	{
		TargetPosition = InitialPosition + Vector3Positions.Right;
		Position = Positions.Right;
	}

	public void MoveDown()
	{
		TargetPosition = InitialPosition + Vector3Positions.Down;
		Position = Positions.Down;
	}

}
