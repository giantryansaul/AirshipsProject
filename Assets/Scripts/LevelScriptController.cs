using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Level", order = 1)]
public class LevelScriptController : ScriptableObject
{
	public int Level;
	public LevelEvent[] Events;
}
