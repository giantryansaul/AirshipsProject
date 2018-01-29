using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingEnemyRadar : MonoBehaviour
{
	private GameObject radarPanelObject;
	private int maxViewDistance = 100;
	private Vector2 radarDimensions;

	public Positions positionEnum;
	public string targetShipName;

	private float ourShipPos;
	private float friendlyShipPos;
	private float offsetPos;

	void Start()
	{
		radarPanelObject = GameObject.Find("RadarPanel");
		radarDimensions = radarPanelObject.GetComponent<RectTransform>().sizeDelta;

		ourShipPos = radarDimensions.x * 0.25f;
		friendlyShipPos = -ourShipPos;
		offsetPos = radarDimensions.x * 0.125f;
		
		transform.position = new Vector2(0, 40); // just to get it out of the way
	}
	
	public void UpdateRadarPosition(Vector2 position)
	{
		if (position.y < maxViewDistance)
		{
			var horPos = 0.0f;
			if (targetShipName == "OurShip")
			{
				horPos = ourShipPos;
			}
			else if (targetShipName == "FriendlyShip")
			{
				horPos = friendlyShipPos;
			}
			
			if (positionEnum == Positions.Left)
				horPos += -offsetPos;
			else if (positionEnum == Positions.Right)
				horPos += offsetPos;
			
			var vertPos = position.y / maxViewDistance;
			
			transform.localPosition = new Vector2(horPos, vertPos * radarDimensions.y);
		}
	}
}
