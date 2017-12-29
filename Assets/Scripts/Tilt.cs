using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilt : MonoBehaviour {

	public float speed = 50;
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey(KeyCode.D))
		{
			TiltLeft();
		}

		if (Input.GetKey(KeyCode.A))
		{
			TiltRight();
		}

		if (Input.GetKey(KeyCode.W))
		{
			TiltBack();
		}

		if (Input.GetKey(KeyCode.S))
		{
			TiltForward();
		}	
	}

	void TiltLeft()
	{
		transform.Rotate(Vector3.left * speed * Time.deltaTime);
	}

	void TiltRight()
	{
		transform.Rotate(Vector3.right * speed * Time.deltaTime);
	}

	void TiltBack()
	{
		transform.Rotate(Vector3.back * speed * Time.deltaTime);
	}

	void TiltForward()
	{
		transform.Rotate(Vector3.forward * speed * Time.deltaTime);
	}
}
