using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class offRoad : MonoBehaviour 
{
	/*function OnTriggerExit (other : Collider) 
 	{
		if(other.gameObject.tag == "Player")
		{
		other.GetComponent.< Car2DController>().offroad = true;
		Debug.Log("Off the Road");
     	}
 	}
 	
	function OnTriggerEnter (other : Collider) 
 	{
		if(other.gameObject.tag == "Player")
		{
			other.GetComponent.< Car2Controller>().offroad = false;
			Debug.Log("back On Track");
     	}
 	}*/

	void OnTriggerExit2D(Collider2D other)
	{
			other.GetComponent<Car2DController>().offroad = true;
			Debug.Log("Off the Road");
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			other.GetComponent<Car2DController>().offroad = false;
		}
	}
}
