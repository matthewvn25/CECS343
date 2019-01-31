using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapCount : MonoBehaviour {

	public Text lapCountText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		lapCountText.text = "Lap: " + GetComponent<Car2DController>().lapCount;
		
	}
}
