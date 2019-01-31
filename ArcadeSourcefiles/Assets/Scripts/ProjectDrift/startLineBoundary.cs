using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startLineBoundary : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		bool check1 = other.GetComponent<Car2DController>().check1;
		bool check2 = other.GetComponent<Car2DController>().check2;
		bool check3 = other.GetComponent<Car2DController>().check3;
		bool check4 = other.GetComponent<Car2DController>().check4;
		if(other.tag == "Player")
		{
			if(check1 == true && check2 == true && check3 == true && check4 == true)
			{
				other.GetComponent<Car2DController>().setCheckpointsFalse();
				other.GetComponent<Car2DController>().lapCount += 1;
				if(other.GetComponent<Car2DController>().lapDisplay == 2)
				{
					other.GetComponent<Car2DController>().lapDisplay = 2;
				}
				else
				{
					other.GetComponent<Car2DController>().lapDisplay += 1;
				}
			}
		}
	}
}
