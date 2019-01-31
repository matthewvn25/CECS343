using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreWriter : MonoBehaviour {
	public int score;
	public string scoreName;

	/**
	 * Writes the score in the scores file
	 * This function should be called after you asked
	 * the user to input his name next to his score
	 */
	public void writeScore() {

		// Initialize path variables
		# if UNITY_STANDALONE_WIN
			string filePath = "Scores\\" + SceneManager.GetActiveScene().name + ".json";
		# else
			string filePath = "Scores/" + SceneManager.GetActiveScene().name + ".json";
		# endif

		// If the score list file exists, add the new score to it
		if (File.Exists(filePath)) {
			string jsonData = File.ReadAllText(filePath);
			Score[] arrayS = null;
			try {
				arrayS = JsonHelper.FromJson<Score>(jsonData);
			} catch (ArgumentException) {
				
			}
			List<Score> scores = new List<Score>();
			if (arrayS != null)
				scores.AddRange(arrayS);
			scores.Add(new Score(scoreName, score));
			File.WriteAllText(filePath, JsonHelper.ToJson<Score>(scores.ToArray(), true));
		}
		// If note, create the file and write the new score to it
		else {
			Score[] s = new Score[1] {new Score(scoreName, score)};
			File.WriteAllText(filePath, JsonHelper.ToJson<Score>(s, true));
		}
	}

	public void setName(string n) {
		scoreName = n;
	}

	public void setScore(int s) {
		score = s;
	}
}
