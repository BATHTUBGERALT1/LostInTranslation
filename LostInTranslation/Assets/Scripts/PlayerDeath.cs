using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player playerScript = collision.collider.GetComponent<Player>();
   
    
    if (playerScript !=null)
        {

        playerScript.Kill(); 

        
        }
    }
}
