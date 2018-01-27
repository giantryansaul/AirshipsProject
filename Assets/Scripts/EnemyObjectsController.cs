using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectsController : MonoBehaviour
{
	private float floatingEnemySpawnTimer;
	private int numberOfFloatingEnemiesLaunched = 0;
	public GameObject FloatingEnemyPrefab;	
	
	// Use this for initialization
	void Start ()
	{
		floatingEnemySpawnTimer = 0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		floatingEnemySpawnTimer += Time.deltaTime;
		
		if (floatingEnemySpawnTimer / 2 > numberOfFloatingEnemiesLaunched)
		{
			Instantiate(FloatingEnemyPrefab);
			numberOfFloatingEnemiesLaunched++;
		}
		
	}
}
