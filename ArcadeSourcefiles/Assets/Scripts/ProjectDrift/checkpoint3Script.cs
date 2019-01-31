using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint3Script : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		bool check1 = other.GetComponent<Car2DController>().check1;
		bool check2 = other.GetComponent<Car2DController>().check2;
		if(other.tag == "Player")
		{
			if(check1 == true && check2 == true)
			{
				other.GetComponent<Car2DController>().setCheck3();
			}
		}
	}
}
