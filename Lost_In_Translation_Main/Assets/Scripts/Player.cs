using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// extra using statemet to allow us to use scene management functions
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    public Animator playerAnimator;
    public SpriteRenderer playerSprite;

    private Rigidbody2D rb;

    private bool facingRight = true;


    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;


    private int extraJumps;
    public int extraJumpsValue;

  


    //variable to reference to the lives display
    public LifeScript livesObject;

    private void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(facingRight == false && moveInput > 0)
        {
            Flip();
        } else if(facingRight == true && moveInput < 0)
        {
            Flip();
        }

        playerAnimator.SetFloat("Walk", Mathf.Abs(moveInput));
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

    }

    private void Update()
    {
        if(isGrounded == true)
        {

            extraJumps = extraJumpsValue;
        }

        if(Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;

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
            SceneManager.LoadScene("SampleScene");

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

 





