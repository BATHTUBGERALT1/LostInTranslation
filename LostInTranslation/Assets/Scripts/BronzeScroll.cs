using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//statement to use ui
using UnityEngine.UI;
public class BronzeScroll : MonoBehaviour {

    //this makes the score visible and easy to drag around on screen 
    public Text scoreText;

    //variable to track the score, and it is private so other scrips cant change it
    // starts at 0

    private int numericalScore = 0;


	// Use this for initialization
	void Start () {

        //got to have the player prefs save between sessions 
        //set at 0 since none has been collected yet 
        // adds to the number score
        numericalScore = PlayerPrefs.GetInt("BronzeScroll", 0);

        //updates it visually 
        scoreText.text = numericalScore.ToString(); 

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //function  for adding to score
    //public so it can be used by other things

    public void AddScore(int _toAdd)
    {
        //adds to numerical score
        numericalScore = numericalScore + _toAdd;

        //update visually 
        scoreText.text = numericalScore.ToString();

    }

    //function to save the score, public as its to save between levels
    public void SaveBronzeScroll()
    {
        PlayerPrefs.SetInt("BronzeScroll", numericalScore);


    }
}
