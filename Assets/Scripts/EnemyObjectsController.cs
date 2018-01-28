using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectsController : MonoBehaviour
{
	private float floatingEnemySpawnTimer;
	private int numberOfFloatingEnemiesLaunched = 0;
	public GameObject FloatingEnemyPrefab;
	public GameObject FloatingEnemyRadarPrefab;

	public GameObject FriendlyShip;
	public GameObject OurShip;
	
	// Use this for initialization
	void Start ()
	{
		floatingEnemySpawnTimer = 0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		floatingEnemySpawnTimer += Time.deltaTime;
		
		if (floatingEnemySpawnTimer / 5 > numberOfFloatingEnemiesLaunched)
		{
			var enemy = Instantiate(FloatingEnemyPrefab);
			var floatingEnemy = enemy.GetComponent<FloatingEnemy>();
			floatingEnemy.ShipToTarget = OurShip;
			floatingEnemy.RadarObjectPrefab = FloatingEnemyPrefab;
			numberOfFloatingEnemiesLaunched++;
		}
		
		if (floatingEnemySpawnTimer / 10 > numberOfFloatingEnemiesLaunched)
		{
			var enemy = Instantiate(FloatingEnemyPrefab);
			enemy.GetComponent<FloatingEnemy>().ShipToTarget = FriendlyShip;
			numberOfFloatingEnemiesLaunched++;
		}
		
	}
}
