using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour {

    //Sets the variable "ScoreValue" to and integar and sets base score to 0
    public static int scoreValue = 0;
    Text score;

    // Use this for initialization
    void Start()
    {

        //tells the program that we will be using the variable "Score" to
        //Give the value to the "Text"
        score = GetComponent<Text>();

        scoreValue = PlayerPrefs.GetInt("score", 0);


    }

    // Update is called once per frame
    void Update()
    {

        score.text = scoreValue.ToString();


    }


    public void SaveScore()
    {
        //sets the score value and save the value 
        PlayerPrefs.SetInt("score", scoreValue);
        PlayerPrefs.Save();
    }

    public static void ResetScore()
    {
        PlayerPrefs.DeleteKey("score");
    }

}

