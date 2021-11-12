using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : MainClass {

	public float maxSpeed = 7;
	public float jumpTakeOffSpeed = 7;


	private SpriteRenderer spriteRenderer;
	private Animator animator;

	// Use this for initialization
	void Awake () 
	{
		spriteRenderer = GetComponent<SpriteRenderer> (); 
		animator = GetComponent<Animator> ();
		curHealth = maxHealth;
		if (curHealth > maxHealth) {
			curHealth = maxHealth;
		}
		if (curHealth <= 0) {
			Die ();
		}
	}

	void update()
	{
		
	}

	public void ComputeVelocity()
	{
		Vector2 move = Vector2.zero;

		move.x = Input.GetAxis ("Horizontal");

		if (Input.GetButtonDown ("Jump") && grounded) {
			velocity.y = jumpTakeOffSpeed;
		} else if (Input.GetButtonUp ("Jump")) 
		{
			if (velocity.y > 0) {
				velocity.y = velocity.y * 0.5f;
			}
		}

		bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
		if (flipSprite) 
		{
			spriteRenderer.flipX = !spriteRenderer.flipX;
		}

		animator.SetBool ("grounded", grounded);
		animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maxSpeed);

		targetVelocity = move * maxSpeed;
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.collider.CompareTag("Obstacle"))
		{
			Destroy (gameObject);
		}
	}

	void Die()
	{
		
	}
}