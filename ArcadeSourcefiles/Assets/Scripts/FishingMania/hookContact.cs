using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookContact : MonoBehaviour
{
    public int score;
    
    public GameObject hook;
    void Start()
    {
        score = 0;
        // Destroy(gameObject, 5); //destroy object in 5 seconds
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        enemyScript hit = otherCollider.gameObject.GetComponent<enemyScript>();
        if (hit != null) //if collided with something
        {
            Destroy(hit.gameObject); //destroy fish 
            /*
            Rigidbody2D rb = hit.gameObject.GetComponent<Rigidbody2D>();
            rb.mass = 5;
            rb.gravityScale = 5;
            */


            //Rigidbody2D rb = hit.gameObject.GetComponent<Rigidbody2D>();
            //rb.MoveRotation(270);
            //hook.GetComponent<Collider2D>().enabled = false;
            //hook.rigidbody2D.isKinematic = true;
            //hook.transform.parent = rb.transform;
            //hook.transform.localPosition = Vector3.zero;
            //rb.transform.parent = transform; //makes fish into child of hook
            //rb.velocity = new Vector2(0,0);
            //rb.Sleep();
            //rb.isKinematic = true;
            

            //Destroy(gameObject); //destroy self
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score", 0) + 20); //add 20 to score
            if (PlayerPrefs.GetInt("score", 0) > PlayerPrefs.GetInt("hscore", 0))
            {
                PlayerPrefs.SetInt("hscore", PlayerPrefs.GetInt("score", 0));
            }
        }

    }

    /*
    public static int getScore()
    {
        return score.getScore();
    }
    */

}

