using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public InputField playerName;
    public ScoreWriter writer;

    public void getInput(string name)
    {
        Debug.Log(name);
    }

    public void setScoreName()
    {
        writer.scoreName = playerName.text;
    }
}
