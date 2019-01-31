using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
#if UNITY_EDITOR
	using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class Loader : MonoBehaviour {
	[SerializeField]
	public GameObject gamesManager = null;
	void Awake() {
		// Instantiate our GameManager Singleton
		# if UNITY_EDITOR
			if (GamesManager.instance == null || FindObjectOfType(typeof(GamesManager)) == null) {
				PrefabUtility.InstantiatePrefab(gamesManager);
			}
		checkPathFolder();
		# endif
	}

	/**
	 * This function will verify if the Games folder is present
	 * If not, create it to prevent further errors
	 */
	static void checkPathFolder() {
		# if UNITY_EDITOR_WIN
			string targetPath = "Assets\\Scenes\\Games\\";
		# else
			string targetPath = "Assets/Scenes/Games/";
		# endif
		if (!System.IO.Directory.Exists(targetPath))
        {
            System.IO.Directory.CreateDirectory(targetPath);
        }
	}

	/**
	 * This function will be called to add a new game to the list
	 */
	 #if UNITY_EDITOR
    [MenuItem("Arcade/Add game")]
    static void AddGame() {

		// Setting up some cross platform variables
		var myRegExp = new Regex("^\\/*(.+\\/)*(.*)(\\.unity)$");
		# if UNITY_EDITOR_WIN
			string targetPath = "Assets\\Scenes\\Games\\";
		# else
			string targetPath = "Assets/Scenes/Games/";
		# endif

		// Check for the presence of a Singleton in the scene
		// Add it if it's present and if the Singleton unexpectedly did not get instantiated 
		GamesManager gm = FindObjectOfType(typeof(GamesManager)) as GamesManager;
        if (gm != null && GamesManager.instance == null) {
            GamesManager.instance = gm;
        }

		// Opens a file explorer to ask the user for a Game
		string filePath = EditorUtility.OpenFilePanel("Add Game", targetPath, "unity");
		if (filePath.Length == 0)
			return ;

		// Transforms the absolute path given by the file explorer
		// into a relative path to eventually perform copies (required by Unity)
		Uri uri = new Uri(filePath);
		string currentPath = Application.dataPath;
		currentPath = currentPath.Remove(currentPath.IndexOf("Assets"));
		filePath = new Uri(currentPath).MakeRelativeUri(uri).ToString();

		// Performs Regex to identify the game name, and verify for duplicates
		string filePathCopy = filePath;
		Match match = myRegExp.Match(filePath);
		string gameName = match.Groups[2].ToString();
		foreach (string s in GamesManager.instance.scenes) {
			if (s == gameName) {
				Debug.Log("That game already exists, that scene will be ignored");
				return ;
			}
		}

		// Adds the required scene to the Game Manager
		GamesManager.instance.scenes.Add(gameName);

		// If the scene file isn't currently in the right folder, copy it
		// into the right one
		# if UNITY_EDITOR_WIN
			filePathCopy = filePathCopy.Replace('/', '\\');
		# endif
		if (filePathCopy != targetPath + gameName + ".unity") {
			System.IO.File.Copy(filePathCopy, targetPath + gameName + ".unity", true);
		}

		// Updating the Build Settings so that the scene is part of the unity build
		var original = EditorBuildSettings.scenes;
        var newSettings = new EditorBuildSettingsScene[original.Length + 1]; 
        System.Array.Copy(original, newSettings, original.Length); 
        var sceneToAdd = new EditorBuildSettingsScene(filePathCopy, true); 
        newSettings[newSettings.Length - 1] = sceneToAdd; 
        EditorBuildSettings.scenes = newSettings;

		// Keeps the changes through edit and play mode
		EditorUtility.SetDirty(GamesManager.instance);
    }

	/**
	* This function will be used to remove the last element of the game list
 	*/
	[MenuItem("Arcade/Remove game")]
    static void RemoveGame()
    {
		GamesManager gm = FindObjectOfType(typeof(GamesManager)) as GamesManager;
        if (gm != null) {
            GamesManager.instance = gm;
        }
		if (GamesManager.instance.scenes.Count > 0) {
			if (EditorBuildSettings.scenes.Length > 1) {
				var original = EditorBuildSettings.scenes;
				var newSettings = new EditorBuildSettingsScene[original.Length - 1];
				System.Array.Copy(original, newSettings, original.Length - 1);
				EditorBuildSettings.scenes = newSettings;	
			}
       		GamesManager.instance.scenes.RemoveAt(GamesManager.instance.scenes.Count - 1);
			EditorUtility.SetDirty(GamesManager.instance);
		}
    }
	#endif
}
