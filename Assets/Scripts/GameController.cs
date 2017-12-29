using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public Text timerText;
	public Text endText;
	public Button newGameButton;
	public Transform floorPosition;
	public Transform ballPosition;
	public GameObject floor;
	float timerTime;
	bool isPlaying;

	// Use this for initialization
	void Start ()
	{
		timerTime = 0.0f;
		isPlaying = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isPlaying == true)
		{		
			timerTime += Time.deltaTime;
			timerText.text = "time without falling: " + timerTime.ToString("n2"); // n2 ensures the number is only 2 decimal places
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		// The Plane in the scene should have the tag DeathPlane. If it doesn't, add it.
		if (other.gameObject.CompareTag ("DeathPlane"))
		{
			isPlaying = false;
			endText.text = "final score: " + timerTime.ToString("n2");

			timerText.gameObject.SetActive(false);
			endText.gameObject.SetActive(true);
			newGameButton.gameObject.SetActive(true);
		}
	}

	// This will be called when the New Game button is pressed
	public void ResetGame()
	{
		// Reset positions, rotations, and velocities

		// Reset the ball ("this" is the ball because this script is on the ball)
		this.gameObject.transform.position = ballPosition.position;
		this.GetComponent<Rigidbody>().velocity = Vector3.zero;
		this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero; // Need to reset angular velocity because the ball is spinning

		// Reset the floor
		floor.gameObject.transform.position = floorPosition.position;
		floor.gameObject.transform.rotation = floorPosition.rotation;
		floor.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

		// Reset the timer
		timerTime = 0.0f;
		isPlaying = true;

		// Reset the UI
		timerText.gameObject.SetActive(true);
		endText.gameObject.SetActive(false);
		newGameButton.gameObject.SetActive(false);
	}
}
