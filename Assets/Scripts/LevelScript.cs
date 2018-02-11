using System;

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
	
	public bool ShowTutorial;
	public string Tutorial;
	public Screens TutorialScreen;

	public enum Screens
	{
		Bow,
		Starboard
	}
	
}

