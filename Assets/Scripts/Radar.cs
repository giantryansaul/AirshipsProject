using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radar : MonoBehaviour
{
	private GameObject radarPanelObject;
	public int maxViewDistance = 20;
	private Vector2 radarDimensions;

	public Positions positionEnum;

	void Start()
	{
		radarPanelObject = GameObject.Find("RadarPanel");
		radarDimensions = radarPanelObject.GetComponent<RectTransform>().sizeDelta;
		Debug.Log(positionEnum);
	}
	
	public void UpdateRadarPosition(Vector2 position)
	{
		if (position.y < maxViewDistance)
		{
			var vertPos = position.y / maxViewDistance;
			var horPos = 0;
			if (positionEnum == Positions.Left)
				horPos = -1;
			else if (positionEnum == Positions.Right)
				horPos = 1;
			
			transform.localPosition = new Vector2(horPos, vertPos * radarDimensions.y);
		}
	}
}
