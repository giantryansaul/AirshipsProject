using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Levels", menuName = "Levels", order = 1)]
public class LevelScriptController : ScriptableObject
{
	public LevelScript[] Levels;
}

[Serializable]
public class LevelScript
{
	public LevelEvent[] Events;
}