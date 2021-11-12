using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

	public Transform originPoint, originPoint2;
	public bool facingRight=true;

	private Vector2 direction= new Vector2(-1,0);
	public	float range, range2;
	public float speed;

	Rigidbody2D rb2d;

	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit2D hit = Physics2D.Raycast (originPoint.position, direction, range);
		RaycastHit2D hit2 = Physics2D.Raycast (originPoint2.position, direction, range2);
		if (hit == true) 
		{
			if (hit.collider.CompareTag("Ground"))
			{
			Flip ();
				speed = -1;
				direction *= -1;
			}
		}

		if (hit == false || hit.collider.CompareTag ("Player")) 
		{
			Flip ();
			speed *= -1;
			direction *= -1;
		}
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		speed *= -1;
	}

	void FixedUpdate()
	{
		rb2d.velocity = new Vector2 (speed, rb2d.velocity.y);
	}
}
