using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

	private GameObject _lastBowTutorial;
	private GameObject _lastStarboardTutorial;
	
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
	
	// Main Game loop is here, most of the game's logic works around this.
	void Update ()
	{
		_floatingEnemySpawnTimer += Time.deltaTime;

		if (!OurShip.GetComponent<ShipHealth>().IsAlive())
		{
			PlayerPrefs.SetString("Game Over Status", "Your ship has been destroyed!");
			SceneManager.LoadScene(2);
		}

		if (!FriendlyShip.GetComponent<ShipHealth>().IsAlive())
		{
			PlayerPrefs.SetString("Game Over Status", "The Bronze Empress has been destroyed!");
			SceneManager.LoadScene(2);
		}
		
		if (_floatingEnemySpawnTimer / ScriptInterval > _scriptTicks)
		{
			StartCoroutine("ExecuteScript", _scriptTicks);
			_scriptTicks++;
			if (_scriptTicks == _currentScript.Events.Length - 1 && _currentLevel == Levels.Levels.Length - 1)
			{
				PlayerPrefs.SetString("Game Over Status", "You saved both ships, you won!");
				SceneManager.LoadScene(2);
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
			var tutorialPF = TutorialPrefab.GetComponent<Tutorial>();
			tutorialPF.Description = levelEvent.Tutorial;
			if (levelEvent.TutorialScreen == LevelEvent.Screens.Bow)
			{
				if (_lastBowTutorial)
					Destroy(_lastBowTutorial);
				_lastBowTutorial = Instantiate(TutorialPrefab);
				_lastBowTutorial.transform.SetParent(BowCanvas.transform, false);
			}
			else if (levelEvent.TutorialScreen == LevelEvent.Screens.Starboard)
			{
				if (_lastStarboardTutorial)
					Destroy(_lastStarboardTutorial);
				_lastStarboardTutorial = Instantiate(TutorialPrefab);
				_lastStarboardTutorial.transform.SetParent(StarboardCanvas.transform, false);
			}
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
