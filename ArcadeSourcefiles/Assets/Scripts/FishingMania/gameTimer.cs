using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameTimer : MonoBehaviour
{
    public float myTimer = 0.0f;
    public float timeLimit;
    public static bool gameEnded = false;
    public GameObject menuContainer; //made so that menu can appear when game has ended
    public ScoreWriter writer;
    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("timer", 0);
        gameEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if ((timeLimit - myTimer) >= 0) //prevents showing negative time. Perhaps there is a better way of doing this
        {
            myTimer += Time.deltaTime;
            this.GetComponent<Text>().text = "Timer : " + (timeLimit - (int)myTimer);
        }
       
        if(myTimer >= timeLimit) //end game when out of time
        {
            gameEnded = true;
           // Debug.Log("ss" + hookContact.getScore());
            writer.score = PlayerPrefs.GetInt("score");
            menuContainer.SetActive(true);
            //game over
        }
    }

    public static bool getGameEnded() //made so that playerMove knows the game has ended
    {
        return gameEnded;
    }


}

/*
using UnityEngine;
using System.Collections;

public class gameTimer : MonoBehaviour

{
    public GUIText timer;
    public float myTimer = 0.0f;
    void Update()
    {
        myTimer += Time.deltaTime;
        timer.text = "Time :" + (int)myTimer;

        if (myTimer >= 300.0f)
        {
            Debug.Log("GAME OVER");
        }

    }
}
*/

/*
using UnityEngine;
using System.Collections;

public class timer : MonoBehaviour
{

    public float targetTime = 60.0f;


 void Update()
    {

        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            timerEnded();
        }

    }

    void timerEnded()
    {
        //GameOver();
    }


}
*/
