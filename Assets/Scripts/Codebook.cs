using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Codebook : MonoBehaviour {

    [SerializeField] public List<InstructionList> codebooks;
    public Image codebookImage;
    public int currentLevel;
    

	// Use this for initialization
	void Start () {
        currentLevel = 0;
        updateCodebook();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void updateCodebook()
    {
        codebookImage.sprite = codebooks[currentLevel].codeImage;
        this.gameObject.GetComponent<Transmission>().codebook = codebooks[currentLevel];
    }

    public void advanceLevel()
    {
        currentLevel++;
        updateCodebook();
    }
}
