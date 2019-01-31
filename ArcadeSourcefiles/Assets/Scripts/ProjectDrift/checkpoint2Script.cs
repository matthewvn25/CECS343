using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint2Script : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			if(other.GetComponent<Car2DController>().check1 == true)
			{
				other.GetComponent<Car2DController>().setCheck2();
			}
		}
	}
}
