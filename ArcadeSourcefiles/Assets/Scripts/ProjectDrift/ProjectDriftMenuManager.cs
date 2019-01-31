using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProjectDriftMenuManager : MonoBehaviour {
	[SerializeField]
	private ScoreWriter writer;
	[SerializeField]
	Text text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void restartGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void sumbitScore() {
		writer.scoreName = text.text;
		if (writer.scoreName.Length > 0)
			writer.writeScore();
	}

	public void loadMainMenu() {
		SceneManager.LoadScene(0);
	}
}
