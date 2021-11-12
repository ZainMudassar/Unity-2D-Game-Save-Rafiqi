using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementThing : MonoBehaviour {

	protected Rigidbody2D player_body;
	Animator playerAnimator;
	Vector2 player_direction;
	public	int JumpMultiplier, speedMultiplier;

	// Use this for initialization
	void Start () 
	{
		player_body = GetComponent<Rigidbody2D>();
//		playerAnimator = GetComponent<Animator>();
		player_body.gravityScale = 0.2f;
		Invoke ("ChangeGravity", 4f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		HandleInput ();	
	}

	void ChangeGravity()
	{
		player_body.gravityScale = 1.2f;
		//playerAnimator.SetBool ("isWalking", false);
		//playerAnimator.SetBool ("isFalling", false);
	}

	void HandleInput()
	{
		float x = Input.GetAxis ("Horizontal");
		///playerAnimator.SetBool ("isWalking", false);
		if (x > 0f) 
		{
		//	playerAnimator.SetBool ("isWalking", true);
			//facingRight = true;
			transform.localScale = new Vector3 (1f, 1f, 1f);
		} 
		else if (x < 0f) 
		{
		//	playerAnimator.SetBool ("isWalking", true);
			//facingRight = false;
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		}

		player_direction = Vector2.right * x;

		if (Input.GetButtonDown("Jump")) 
		{
			Jump();
		}

	}

	void FixedUpdate()
	{
		Movement ();
	}

	void Jump()
	{
		player_body.velocity = Vector2.up * JumpMultiplier;
	}

	void Movement()
	{
		player_body.velocity = new Vector2 (player_direction.x * speedMultiplier, player_body.velocity.y);
	}
}
