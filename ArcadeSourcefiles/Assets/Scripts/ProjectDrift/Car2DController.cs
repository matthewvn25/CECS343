using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car2DController : MonoBehaviour {

	public float speedForce = 10f;
	float torqueForce = -200f;
	float driftFactorSlippy = 1f;
	float driftFactorSticky = 0.97f;
	float maxStickyVelocity = 2.5f;
	//float minSlippyVelocity = 1.5f;
	public bool offroad = false;
	public int lapCount;
	public int lapDisplay;
	public int checkLap;

	public bool check1 = false;
	public bool check2 = false;
	public bool check3 = false;
	public bool check4 = false;

	public bool endTime;

	public Text lapCountText;
	public Text startFinishText;
	int countdownNum;

	public Text check1T;
	public Text check2T;
	public Text check3T;
	public Text check4T;


	// Use this for initialization
	void Start () {
		lapCount = checkLap = 0;
		lapDisplay= 1;
		endTime = false;
		setLapCount();
		freezePlayer();
		startRace();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Rigidbody2D rb = GetComponent<Rigidbody2D>();

		setLapCount();
		setCheckpointText();

		float driftFactor = driftFactorSticky;
		if(RightVelocity().magnitude > maxStickyVelocity)
		{
			driftFactor = driftFactorSlippy;
		}

		rb.velocity = ForwardVelocity() + RightVelocity() * driftFactor;

		float move = Input.GetAxis("Vertical");
		if(move > 0)
		{
			if(offroad == true)
			{
				rb.AddForce(transform.up * speedForce/4);
			}
			else
			{
				rb.AddForce(transform.up * speedForce);
			}
			
		}
		else if (move < 0)
		{
			rb.AddForce(transform.up * -speedForce/4);
		}

		float tf = Mathf.Lerp(0, torqueForce, rb.velocity.magnitude / 2);	
		rb.angularVelocity = Input.GetAxis("Horizontal") * tf;
	}

	Vector2 ForwardVelocity()
	{
		return transform.up * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.up);
	}

	Vector2 RightVelocity()
	{
		return transform.right * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.right);
	}

	void setLapCount()
	{
		lapCountText.text = "Lap: " + lapDisplay.ToString();
	}

	void freezePlayer()
	{

		GetComponent<Car2DController>().enabled = false;
	}

	void unfreezePlayer()
	{
		GetComponent<Car2DController>().enabled = true;
	}

	void startRace()
	{
		startFinishText.enabled = true;
		countdownNum = 3;
		InvokeRepeating("countDown", 0.0f, 1.0f);
	}

	void endRace()
	{
		endTime = true;
		startFinishText.enabled = true;
		startFinishText.text = "Finish!";
		freezePlayer();
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if(other.tag == "startLine")
		{
			if(lapCount == 1 && check1 == true && check2 == true && check3 == true && check4 == true )
			{
				endRace();
			}
		}
	}

	void countDown()
	{
		if(countdownNum == 0)
		{
			startFinishText.text = "Go!";
		}
		else
		{
			startFinishText.text = countdownNum.ToString();
		}

		if(countdownNum <= -1)
		{
			startFinishText.enabled = false;
			CancelInvoke();
		}

		if(countdownNum == 0)
		{
			unfreezePlayer();
		}

		countdownNum--;
	}

	public void setCheckpointsFalse()
	{
		check1 = check2 = check3 = check4 = false;
	}

	public void setCheck1()
	{
		check1 = true;
	}

	public void setCheck2()
	{
		check2 = true;
	}

	public void setCheck3()
	{
		check3 = true;
	}

	public void setCheck4()
	{
		check4 = true;
	}

	void setCheckpointText()
	{
		if(check1 == true)
		{
			check1T.text = "Checkpoint 1: ✔";
		}
		else
		{
			check1T.text = "Checkpoint 1: X";
		}
		if(check2 == true)
		{
			check2T.text = "Checkpoint 2: ✔";
		}
		else
		{
			check2T.text = "Checkpoint 2: X";
		}
		if(check3 == true)
		{
			check3T.text = "Checkpoint 3: ✔";
		}
		else
		{
			check3T.text = "Checkpoint 3: X";
		}
		if(check4 == true)
		{
			check4T.text = "Checkpoint 4: ✔";
		}
		else
		{
			check4T.text = "Checkpoint 4: X";
		}
	}


}
