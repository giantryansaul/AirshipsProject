using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyObjectsController : MonoBehaviour
{
	private float _floatingEnemySpawnTimer;

	public float ScriptInterval = 5.0f;
	private int _scriptTicks;
	
	public GameObject FloatingEnemyPrefab;
	public GameObject FloatingEnemyRadarPrefab;

	public GameObject TutorialPrefab;
	public GameObject StarboardCanvas;
	public GameObject BowCanvas;

	public GameObject FriendlyShip;
	public GameObject OurShip;

	public LevelScriptController Levels;

	private int _currentLevel;
	private LevelScript _currentScript;
	
	void Start ()
	{
		_floatingEnemySpawnTimer = 0f;
		FloatingEnemyPrefab.GetComponent<FloatingEnemy>().RadarObjectPrefab = FloatingEnemyRadarPrefab;
		SetLevel();
	}

	private void SetLevel()
	{
		_currentScript = Levels.Levels[_currentLevel];
	}

	void Update ()
	{
		_floatingEnemySpawnTimer += Time.deltaTime;
		
		if (_floatingEnemySpawnTimer / ScriptInterval > _scriptTicks)
		{
			StartCoroutine("ExecuteScript", _scriptTicks);
			_scriptTicks++;
			if (_scriptTicks == _currentScript.Events.Length - 1 && _currentLevel == Levels.Levels.Length - 1)
			{
				Debug.Log("GAME OVER");
				Application.Quit();
				return;
			}
			
			if (_scriptTicks == _currentScript.Events.Length - 1)
			{
				_currentLevel++;
				SetLevel();
			}
		}
	}

	private IEnumerator ExecuteScript(int scriptPos)
	{
		var levelEvent = _currentScript.Events[scriptPos];
		if (levelEvent.LaunchEnemy)
		{
			if (levelEvent.LaunchAtShips == LevelEvent.Ships.Friendly)
				InstantiateFloatingEnemies(FriendlyShip, levelEvent);
			if (levelEvent.LaunchAtShips == LevelEvent.Ships.Ours)
				InstantiateFloatingEnemies(OurShip, levelEvent);
		}

		if (levelEvent.ShowTutorial)
		{
			Debug.Log(levelEvent.Tutorial + " " + levelEvent.TutorialScreen);
			var tutorialPF = TutorialPrefab.GetComponent<Tutorial>();
			tutorialPF.Description = levelEvent.Tutorial;
			var tutorial = Instantiate(TutorialPrefab);
			if (levelEvent.TutorialScreen == LevelEvent.Screens.Bow)
				tutorial.transform.SetParent(BowCanvas.transform, false);
			else if (levelEvent.TutorialScreen == LevelEvent.Screens.Starboard)
				tutorial.transform.SetParent(StarboardCanvas.transform, false);
		}
			
		yield return null;
	}

	private void InstantiateFloatingEnemies(GameObject shipToTarget, LevelEvent levelEvent)
	{
		var positions = new List<Positions>();
		if (levelEvent.Up)
			positions.Add(Positions.Up);
		if (levelEvent.Left)
			positions.Add(Positions.Left);
		if (levelEvent.Right)
			positions.Add(Positions.Right);
		if (levelEvent.Down)
			positions.Add(Positions.Down);

		var floatingEnemy = FloatingEnemyPrefab.GetComponent<FloatingEnemy>();
		foreach (var position in positions)
		{
			floatingEnemy.StartPosition = position;
			floatingEnemy.ShipToTarget = shipToTarget;
			Instantiate(FloatingEnemyPrefab);
		}
	}
}
