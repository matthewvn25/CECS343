using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {
	public string levelName;
	public MenuManager mn;

	/**
	 * Load the desired game
	 */
	public void loadScene() {
		SceneManager.LoadScene(levelName);
	}

	/**
	 * Displays the desired game's leaderboard
	 */
	public void displayLeaderBoard() {
		if (mn != null)
			mn.displayGameLeaderboard(levelName);
	}
}
