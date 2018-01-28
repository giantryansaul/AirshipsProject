using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radar : MonoBehaviour
{
	public GameObject EnemyObject;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		var position = EnemyObject.GetComponent<ObjectMovement>().GetCurrent2Dposition();
		transform.position = position;
		Debug.Log(position);
	}
}
