using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkJumpFire : MonoBehaviour {

	Rigidbody2D rb;
	float dirX;

	[SerializeField]
	float moveSpeed = 5f, jumpForce = 600f, bulletSpeed = 500f;

	bool facingRight = true;
	Vector3 localScale;

	public Transform barrel;
	public Rigidbody2D bullet;

	// Use this for initialization
	void Start () {
		localScale = transform.localScale;
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		dirX = Input.GetAxis ("Horizontal");

		if (Input.GetButtonDown ("Jump"))
			Jump ();
		
		if (Input.GetKeyDown(KeyCode.V))
			Fire ();
	}

	void FixedUpdate()
	{
		rb.velocity = new Vector2 (dirX * moveSpeed, rb.velocity.y);
	}

	void LateUpdate()
	{
		CheckWhereToFace ();
	}

	void CheckWhereToFace()
	{
		if (dirX > 0)
			facingRight = true;
		else
			if (dirX < 0)
				facingRight = false;
		if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
			localScale.x *= -1;
		transform.localScale = localScale;
	}

	void Jump()
	{
		if (rb.velocity.y == 0)
			rb.AddForce (Vector2.up * jumpForce);
	}

	void Fire()
	{
		var firedBullet = Instantiate (bullet, barrel.position, barrel.rotation);
		firedBullet.AddForce (barrel.up * bulletSpeed);
	}
}
