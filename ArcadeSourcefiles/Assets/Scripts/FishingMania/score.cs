using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    //public hookContact hookCon;
    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("score", 0); //initialize score
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Text>().text = "Score : " + PlayerPrefs.GetInt("score"); //update score
    }

    /*
    public int getScore()
    {
        return PlayerPrefs.GetInt("score");
    }
    */

}