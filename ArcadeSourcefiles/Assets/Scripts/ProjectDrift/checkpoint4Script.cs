using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint4Script : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		bool check1 = other.GetComponent<Car2DController>().check1;
		bool check2 = other.GetComponent<Car2DController>().check2;
		bool check3 = other.GetComponent<Car2DController>().check3;
		if(other.tag == "Player")
		{
			if(check1 == true && check2 == true && check3 == true)
			{
				other.GetComponent<Car2DController>().setCheck4();
			}
		}
	}
}
