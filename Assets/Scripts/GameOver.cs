using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class GameOver : MonoBehaviour
{
	private float _endGameTimer;
	public float stayOpen = 10.0f;
	
	void Start () {
		var status = PlayerPrefs.GetString("Game Over Status", "You Lost");
		gameObject.GetComponent<Text>().text = "Game Over\n" + status;
	}

	void Update()
	{
		if (Input.anyKeyDown)
			Application.Quit();
		_endGameTimer += Time.deltaTime;
		if (_endGameTimer > stayOpen)
			Application.Quit();
	}
}
