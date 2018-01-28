using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Codebook : MonoBehaviour {

    [SerializeField] public List<InstructionList> codebooks;
    public Image codebookImage;
    public int currentLevel;

    [SerializeField] public float levelLengthInSeconds;
    private float levelTimer;

	// Use this for initialization
	void Start () {
        currentLevel = 0;
        updateCodebook();
        levelTimer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {

        // levels increase based on length of time
		if (currentLevel < 2)
        {
            levelTimer += Time.deltaTime;
            if (levelTimer >= levelLengthInSeconds)
            {
                advanceLevel();
                levelTimer = 0.0f;
            }
        }
	}

    public void updateCodebook()
    {
        codebookImage.sprite = codebooks[currentLevel].codeImage;
        this.gameObject.GetComponent<Transmission>().codebook = codebooks[currentLevel];
    }

    public void advanceLevel()
    {
        if (currentLevel < 2)
        {
            currentLevel++;
            Debug.Log("Current Level: " + currentLevel);
            updateCodebook();
        }
    }
}
