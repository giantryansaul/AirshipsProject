using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEnemy : MonoBehaviour
{
	private ObjectMovement movement;
	private int DestoryRangeZ = -50;
	public GameObject ShipToTarget;
	public GameObject RadarObjectPrefab;
	private GameObject RadarObject;
	
	void Start ()
	{
		var startPosition = StartPositionGenerator.GenerateLanePosition();
		var startPosV3 = StartPositionGenerator.GenerateFloatingEnemyStartPosition(startPosition, ShipToTarget.transform.position);
		gameObject.transform.position = startPosV3;
		movement = new ObjectMovement(0, 0, -10, startPosV3);

		RadarObject = Instantiate(RadarObjectPrefab);
		var radarComponent = RadarObject.GetComponent<FloatingEnemyRadar>();
		radarComponent.positionEnum = startPosition;
		radarComponent.targetShipName = ShipToTarget.name;
		RadarObject.transform.SetParent(GameObject.Find("RadarPanel").transform, false);
	}
	
	void Update ()
	{
		gameObject.transform.position = movement.GetUpdatedPosition(Time.deltaTime);
		RadarObject.GetComponent<FloatingEnemyRadar>().UpdateRadarPosition(movement.GetCurrent2Dposition());
		if (gameObject.transform.position.z <= DestoryRangeZ)
			DestroyObject();
	}

	private void DestroyObject()
	{
		Destroy(RadarObject);
		Destroy(gameObject);
	}

	private void OnCollisionEnter(Collision collision)
	{
		DestroyObject();
		
		Debug.Log("BOOM " + collision.gameObject.name);
        GameObject.Find("AudioManager").GetComponent<AudioManager>().playImpactSFX();
	}
}
