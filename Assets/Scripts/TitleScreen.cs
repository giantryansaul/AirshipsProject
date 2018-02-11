using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{

	public GameObject PigSquadLogo;
	public GameObject Title;
	public GameObject Credits;

	private List<GameObject> _titleScreenElements = new List<GameObject>();
	
	void Start () {
		_titleScreenElements.Add(PigSquadLogo);
		_titleScreenElements.Add(Title);
		_titleScreenElements.Add(Credits);
		foreach (var element in _titleScreenElements)
		{
			element.SetActive(false);
		}

		PigSquadLogo.SetActive(true);
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Game Quit");
            Application.Quit();
        }

		if (Input.anyKeyDown)
		{
			AdvanceTitleScreen();
			new WaitForSeconds(1);
		}
		
	}

	private void AdvanceTitleScreen()
	{
		_titleScreenElements[0].SetActive(false);
		_titleScreenElements.RemoveAt(0);
		if (_titleScreenElements.Count > 0)
		{
			_titleScreenElements[0].SetActive(true);
			
		}
		else
		{
			startGame();
		}
	}

    public void startGame()
    {
        GameObject musicObject = GameObject.Find("Music");
        if (musicObject)
            musicObject.GetComponent<AudioSource>().Stop();

        SceneManager.LoadScene(1);
    }
}
