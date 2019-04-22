using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class LifeScript : MonoBehaviour {

    public Text livesText;
    private int numericalLives = 3;


    // Use this for initialization
    void Start()
    {
        numericalLives = PlayerPrefs.GetInt("lives", 3);
        livesText.text = numericalLives.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoseLife()
    {
        numericalLives = numericalLives - 1;

        livesText.text = numericalLives.ToString();

    }

    public void SaveLives()
    {

        PlayerPrefs.SetInt("lives", numericalLives);

    }

    public bool isGameOver()
    {
        if (numericalLives <= 0)
        {

            return true;
        }
        else
        {
            return false;

        }

    }
}