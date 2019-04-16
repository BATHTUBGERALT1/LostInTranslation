﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//allows scene management functionality 
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{


    // custom variables 
    public float speed = 10;
    public float jumpSpeed = 10;
    public Rigidbody2D physicsBody;
    public string horizontalAxis = "Horizontal";
    public string jumpButton = "Submit";

    public Animator playerAnimator;
    public SpriteRenderer playerSprite;
    public Collider2D playerCollider;
 

    //variable to reference to the lives display
    public LifeScript livesObject;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Get axis input from Unity
        float leftRight = Input.GetAxis(horizontalAxis);


        // Create direction vector from axis input
        Vector2 direction = new Vector2(leftRight, 0);

        // Make direction vector length 1
        direction = direction.normalized;

        // Calculate velocity
        Vector2 velocity = direction * speed;
        velocity.y = physicsBody.velocity.y;

        // Give the velocity to the rigidbody
        physicsBody.velocity = velocity;

        //Tell the animator our speed
        playerAnimator.SetFloat("Walk", Mathf.Abs(leftRight));

        //Flip our sprite if we're moving backwards
        if (velocity.x < 0)
        {
            playerSprite.flipX = true;
        }
        else
        {
            playerSprite.flipX = false;
        }

        // this will get our layer from our added layer ground and detects 
        // if we are touching the ground
        LayerMask groundLayerMask = LayerMask.GetMask("Ground");

        // add a bool to see if we are infact touching ground 
        bool touchingGround = playerCollider.IsTouchingLayers(groundLayerMask);

        //detects input of jump button
        bool jumpButtonPressed = Input.GetButtonDown(jumpButton);

        // detects if player is touching ground 
        if (jumpButtonPressed == true && touchingGround == true)
        {
            // after pressing jump we need to sort out the velocity
            velocity.y = jumpSpeed;


            // this adds velocity to the rigid body 
            physicsBody.velocity = velocity;



        }
    }

    //this is for dealing with the players death
    public void Kill()
    {
        //takes away lives and saves the changes made
        livesObject.LoseLife();
        livesObject.SaveLives();

        //checks if its game over
        bool gameOver = livesObject.isGameOver();


        if (gameOver == true)
        {
            //if game is over load game over
            SceneManager.LoadScene("Level1");

        }
        else
        {
            // if it isnt game over...
            // reset to beginning 


            //check current level
            Scene currentLevel = SceneManager.GetActiveScene();

            //second tell unity to reload level
            SceneManager.LoadScene(currentLevel.buildIndex);


        }
    }

}