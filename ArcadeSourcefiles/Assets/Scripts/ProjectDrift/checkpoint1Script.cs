﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint1Script : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			other.GetComponent<Car2DController>().setCheck1();
		}
	}
}
