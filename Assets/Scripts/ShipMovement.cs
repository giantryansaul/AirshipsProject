using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
	private Vector3 TargetPosition;
	private Quaternion TargetRotation;
	private Vector3 InitialPosition;
	private Quaternion InitialRotation;
	public Positions Position;

	private class Vector3Movement
	{
		public static Vector3 Up = new Vector3(0, 5, 0);
		public static Vector3 Down = new Vector3(0, 0, 0);
		public static Vector3 Left = new Vector3(-5, 5, 0);
		public static Vector3 Right = new Vector3(5, 5, 0);
	}

	public enum Positions
	{
		Up,
		Down,
		Left,
		Right
	}
	
	void Start ()
	{
		InitialPosition = transform.position;
		InitialRotation = transform.rotation;
		MoveDown();
	}
	
	public float interpVelocity = 1.0f;
	private Vector3 targetPos;
	private bool MoveShip = false;

	public float closeDistance = 0.2f;

	void Update()
	{
		SmoothMovementToTarget();
		
		//Consider removing rotation part, it is not working very well
		if (Math.Abs(TargetPosition.x) - Math.Abs(transform.position.x) < closeDistance &&
		    Math.Abs(TargetPosition.y) - Math.Abs(transform.position.y) < closeDistance)
		{
			TargetRotation = InitialRotation;
		}
		transform.rotation = Quaternion.Lerp(transform.rotation, TargetRotation, 0.1f);
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

	public int rotationAngle = 15;

	public void MoveUp()
	{
		TargetPosition = InitialPosition + Vector3Movement.Up;
		TargetRotation = Quaternion.Euler(-rotationAngle, 0, 0);
		Position = Positions.Up;
	}

	public void MoveLeft()
	{
		TargetPosition = InitialPosition + Vector3Movement.Left;
		TargetRotation = Quaternion.Euler(0, -rotationAngle, 0);
		Position = Positions.Left;
	}

	public void MoveRight()
	{
		TargetPosition = InitialPosition + Vector3Movement.Right;
		TargetRotation = Quaternion.Euler(0, rotationAngle, 0);
		Position = Positions.Right;
	}

	public void MoveDown()
	{
		TargetPosition = InitialPosition + Vector3Movement.Down;
		TargetRotation = Quaternion.Euler(rotationAngle, 0, 0);
		Position = Positions.Down;
	}

}
