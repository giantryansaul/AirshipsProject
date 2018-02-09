using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public class LevelEvent
{
	public bool LaunchEnemy;
	public Ships LaunchAtShips;
	public bool Up;
	public bool Left;
	public bool Right;
	public bool Down;
	
	public enum Ships
	{
		Ours,
		Friendly
	}
	
	public bool ShowInstructions;
	public string Instructions;
	public Screens InstructionsScreen;

	public enum Screens
	{
		Bow,
		Starboard
	}
	
}

