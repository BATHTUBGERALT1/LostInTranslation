using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenScroll : MonoBehaviour {

    //variable for adding to the score
    public BronzeScroll scoreObject;

    //variable for the scrolls value 
    public int BronzeScrollValue;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //this deletes the sugar on collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //checks if player actuallyt collided
        Player playerScript = collision.collider.GetComponent<Player>();

        //if we touch something that has the player script we die

        if(playerScript)
        {

            //weve hit the scroll
            //add score
            scoreObject.AddScore(BronzeScrollValue);
            //we have hit the player kill the object
            Destroy(gameObject);

        }
    }
}
