using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	[SerializeField]
	private GameObject gameList;
	[SerializeField]
	private GameObject leaderboardList;
	[SerializeField]
	private GameObject mainMenu;
	[SerializeField]
	private GameObject gameLeaderboard;


	[SerializeField]
	private GameObject buttonGamePrefab;
	[SerializeField]
	private GameObject buttonLeaderboardPrefab;
	[SerializeField]
	private GameObject slotPrefab;

	private GameObject[] slots = new GameObject[10];

	void Start () {
		// Instantiate 10 Score prefabs, representing a slot in the leaderboard
		for (int j = 0 ; j < slots.Length ; ++j) {
			slots[j] = Instantiate(slotPrefab);
			slots[j].transform.SetParent(gameLeaderboard.transform);
			slots[j].transform.localPosition = new Vector3(0, -60 * j + 275, 0);

		}

		// Update list of buttons in terms of the game list
		// 2 sets of buttons are created, one for the list of leaderboards
		// one for the in-game game list
		displayGameList();
		int i = 0;
		foreach (string s in GamesManager.instance.scenes) {
			// Instantiate
			var button = Instantiate(buttonGamePrefab).GetComponent<Button>();
			var button2 = Instantiate(buttonLeaderboardPrefab).GetComponent<Button>();

			// Sets the parameters required for the listener
			var rectTransform = button.GetComponent<RectTransform>();
			ButtonManager bm = button.GetComponent<ButtonManager>();
			bm.levelName = s;
			bm.mn = this;
			var rectTransform2 = button2.GetComponent<RectTransform>();
			bm = button2.GetComponent<ButtonManager>();
			bm.levelName = s;
			bm.mn = this;

			// Sets the button in the right hierarchy in our menus		
			rectTransform.SetParent(gameList.GetComponent<RectTransform>());
			button.transform.localPosition = new Vector3(0, -120 * i, 0);
			rectTransform2.SetParent(leaderboardList.GetComponent<RectTransform>());
			button2.transform.localPosition = new Vector3(0, -120 * i, 0);

			// Sets the right name for the right button
			button2.GetComponentInChildren<Text>().text = s;
			button.GetComponentInChildren<Text>().text = s;
			++i;
		}

		// Show only the buttons of the main menu
		displayMainMenu();
	}

	private void checkScoreFolder() {
		# if UNITY_EDITOR_WIN
			string targetPath = "Scores\\";
		# else
			string targetPath = "Scores/";
		# endif
		if (!System.IO.Directory.Exists(targetPath))
        {
            System.IO.Directory.CreateDirectory(targetPath);
        }
	}

	/**
	 * Updates the leaderboard content according to the selected game
	 */
	public void displayGameLeaderboard(string gameName) {
		checkScoreFolder();
		// Hide all the other menus except this one
		if (gameLeaderboard)
			gameLeaderboard.SetActive(true);
		if (leaderboardList)
			leaderboardList.SetActive(false);
		if (mainMenu)
			mainMenu.SetActive(false);
		if (gameList)
			gameList.SetActive(false);

		// Initialize path variable
		# if UNITY_STANDALONE_WIN
			string path = "Scores\\" + gameName + ".json";
		# else
			string path = "Scores/" + gameName + ".json";
		# endif

		// Reads the content of the score file
		// and deserialize the json content inside an array.
		string jsonData = "";
		Score[] scores = null;
		if (!File.Exists(path)) {
			// Check if the score file is present, if not create one
			scores = new Score[1] {new Score("------", 0)};
 			File.WriteAllText(path, JsonHelper.ToJson(scores, true));
            Debug.Log("Highscore file not present, creating one");
		}
		// Read
		jsonData = File.ReadAllText(path);
		//Deserialize
		scores = JsonHelper.FromJson<Score>(jsonData);
		// Check for corrupted json file
		if (scores != null) {
			// Sort the list and remove excessive slots
			List<Score> s = new List<Score>(scores);
			s.Sort();
			s.Reverse();
			if (s.Count > 10)
				s.RemoveRange(10, s.Count - 10);
			// Rewrite in the json file
			scores = s.ToArray();
			File.WriteAllText(path, JsonHelper.ToJson(scores, true));
		}
		
		// Then updates the score slots according to their position
		for (int i = 0 ; i < slots.Length ; ++i) {
			slotManager sm = slots[i].GetComponent<slotManager>();
			sm.placeText.text = (i + 1).ToString();
			if (scores != null && i < scores.Length) {
				sm.scoreText.text = scores[i].score.ToString();
				sm.nameText.text = scores[i].name.ToString();
			}
			// If the array of score is less than 10, displays a default slot
			else {
				sm.scoreText.text = "0";
				sm.nameText.text = "-------";
			}
		}
	}

	/**
	 * Shows the Game list menu and hides the rest
	 */
	public void displayGameList() {
		if (gameLeaderboard)
			gameLeaderboard.SetActive(false);
		if (leaderboardList)
			leaderboardList.SetActive(false);
		if (mainMenu)
			mainMenu.SetActive(false);
		if (gameList)
			gameList.SetActive(true);
	}

	/**
	 * Shows the Leaderboard list menu and hides the rest
	 */
	public void displayLeaderBoardList() {
		if (gameLeaderboard)
			gameLeaderboard.SetActive(false);
		if (mainMenu)
			mainMenu.SetActive(false);
		if (gameList)
			gameList.SetActive(false);
		if (leaderboardList)
			leaderboardList.SetActive(true);
	}

	/**
	 * Shows the main menu and hides the rest
	 */
	public void displayMainMenu() {
		if (gameLeaderboard)
			gameLeaderboard.SetActive(false);
		if (gameList)
			gameList.SetActive(false);
		if (leaderboardList)
			leaderboardList.SetActive(false);
		if (mainMenu)
			mainMenu.SetActive(true);
	}

	/**
	 * Exits the game of stop the editing mode
	 */
	public void exitApp() {
		#if UNITY_EDITOR
         	UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
	}
}
