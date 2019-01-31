using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour 
{

	public Text timerText;
	private float startTime;
	float timer;
	bool keepTiming;
	float finalTime;

	private GameObject carControl;
	private Car2DController carScript;
	private bool endTime;

	public Text scoreText;
	public GameObject submitScore;
	public ScoreWriter writer;

	// Use this for initialization
	void Start () {
		scoreText.enabled = false;
		//submitScore.SetActive(false);
		carControl  = GameObject.Find("Player");
		carScript = carControl.GetComponent<Car2DController>();
		StartCoroutine(waitThreeSeconds());
	}
	
	// Update is called once per frame
	void Update () {
		endTime = carScript.endTime;
		if(endTime == true)
		{
			keepTiming = false;
			finalTime = StopTimer();
			scoreText.enabled = true;
			scoreText.text = "Final Time:\n" + TimeToString(finalTime);
			submitScore.SetActive(true);
			writer.score = 1000000 / ((int)finalTime * 100);
		}
		if(keepTiming)
		{
			UpdateTime();
		}
	}

	void UpdateTime()
	{
		timer = Time.time - startTime;
        timerText.text = "Time: " + TimeToString(timer);
	}

	float StopTimer()
	{
		Debug.Log("Finish");
		keepTiming = false;
		return timer;
	}

	void ResumeTimer()
	{
		keepTiming = true;
		startTime = Time.time - timer;
	}

	void StartTimer()
	{
		keepTiming = true;
		startTime = Time.time;
	}

	string TimeToString(float t)
	{
		string minutes = ((int) t / 60).ToString();
		string seconds = (t % 60).ToString("f2");

		return minutes + ":" + seconds;
	}

	IEnumerator waitThreeSeconds()
	{
		yield return new WaitForSeconds(3);
		StartTimer();		
	}
}
