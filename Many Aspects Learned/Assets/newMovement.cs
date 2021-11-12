using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newMovement : MonoBehaviour {

	private bool moveLeft;
	private bool moveRight;
	public GameObject player;
	public int forwardSpeed;

	void Update()
	{
		if (moveLeft) {
			Debug.Log ("left");
		//	player.transform.position.x = player.transform.position.x + 3;
			//rigidbody2D.AddForce (Vector2.left * forwardSpeed);
		}
		if(moveRight && !moveLeft){
			//rigidbody2D.AddForce (Vector2.right * forwardSpeed);
		}
	}

	public void MoveMeLeft()
	{
		moveLeft = true;
	}

	public void StopMeLeft()
	{
		moveLeft = false;
	}
}
