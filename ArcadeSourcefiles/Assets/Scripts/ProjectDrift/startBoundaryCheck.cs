using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startBoundaryCheck : MonoBehaviour {

	Collider2D startBoundaryCollider;

	void Start()
	{
		startBoundaryCollider = GetComponent<Collider2D>();
		startBoundaryCollider.isTrigger = true;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			if(other.GetComponent<Car2DController>().lapCount == other.GetComponent<Car2DController>().checkLap)
			{
				startBoundaryCollider.isTrigger = false;
				Debug.Log("Trigger");
			}
			else if(other.GetComponent<Car2DController>().lapCount > other.GetComponent<Car2DController>().checkLap)
			{
				startBoundaryCollider.isTrigger = true;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			other.GetComponent<Car2DController>().checkLap += 1;
		}
	}
}
