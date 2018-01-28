using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectsController : MonoBehaviour
{
	private float floatingEnemySpawnTimer;
	private int numberOfFloatingFriendly = 0;
	private int numberOfFloatingOurShip = 0;
	public GameObject FloatingEnemyPrefab;
	public GameObject FloatingEnemyRadarPrefab;

	public GameObject FriendlyShip;
	public GameObject OurShip;
	
	// Use this for initialization
	void Start ()
	{
		floatingEnemySpawnTimer = 0f;
		FloatingEnemyPrefab.GetComponent<FloatingEnemy>().RadarObjectPrefab = FloatingEnemyRadarPrefab;
	}
	
	// Update is called once per frame
	void Update ()
	{
		floatingEnemySpawnTimer += Time.deltaTime;
		
		if (floatingEnemySpawnTimer / 5 > numberOfFloatingFriendly)
		{
			InstantiateFloatingEnemy(OurShip);
			numberOfFloatingFriendly++;
		}
		
		if (floatingEnemySpawnTimer / 10 > numberOfFloatingOurShip)
		{
			InstantiateFloatingEnemy(FriendlyShip);
			numberOfFloatingOurShip++;
		}
		
	}

	private void InstantiateFloatingEnemy(GameObject ShipToTarget)
	{
		FloatingEnemyPrefab.GetComponent<FloatingEnemy>().ShipToTarget = ShipToTarget;
		Instantiate(FloatingEnemyPrefab);
	}
}
