using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRadar : MonoBehaviour
{
	public GameObject ship;
	private Positions position;
	public RectTransform radarPanelObject;
	private Vector2 radarDimensions;

	private float shipOffset;
	private float positionOffset;
	private float shipPosition;
	
	void Start ()
	{
		radarDimensions = radarPanelObject.sizeDelta;
		shipOffset = radarDimensions.x * 0.25f;
		if (ship.name == "FriendlyShip")
			shipOffset = -shipOffset;
		positionOffset = radarDimensions.x * 0.125f;
	}
	
	void Update ()
	{
		position = ship.GetComponent<ShipMovement>().Position;

		if (position == Positions.Right)
			shipPosition = shipOffset + positionOffset;
		else if (position == Positions.Left)
			shipPosition = shipOffset - positionOffset;
		else
			shipPosition = shipOffset;
			
		transform.localPosition = new Vector2(shipPosition, 20);
	}
}
