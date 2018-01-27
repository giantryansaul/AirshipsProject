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
		Debug.Log("Time " + floatingEnemySpawnTimer);
		if (floatingEnemySpawnTimer / 10 > numberOfFloatingEnemiesLaunched)
		{
			Debug.Log("number of enemies " + numberOfFloatingEnemiesLaunched);
			Instantiate(FloatingEnemyPrefab);
			numberOfFloatingEnemiesLaunched++;
		}
		
	}
}
