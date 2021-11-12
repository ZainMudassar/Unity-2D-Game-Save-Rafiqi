using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainClass : MonoBehaviour {

	public float minGroundNormalY = .65f;
	public float gravityModifier = 1f;
	public int curHealth;
	public int maxHealth = 5;
	public bool facingRight=true;
	protected float rotationZ;
	public Canvas canvas;

	protected new Renderer renderer;
	public GameMaster gM;
	protected Water water;
	protected Vector2 targetVelocity;
	protected bool grounded;
	protected bool throws;
	public bool hurt;

	protected Vector2 groundNormal;
	protected Rigidbody2D rb2d;
	protected Vector2 velocity;
	protected ContactFilter2D contactFilter;
	protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
	protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D> (16);



	protected const float minMoveDistance = 0.001f;
	protected const float shellRadius = 0.01f;

	void OnEnable()
	{
		rb2d = GetComponent<Rigidbody2D> ();
	//	water = GameObject.FindGameObjectWithTag ("Water").GetComponent<Water> ();

	}

	void Start () 
	{
		contactFilter.useTriggers = false;
		contactFilter.SetLayerMask (Physics2D.GetLayerCollisionMask (gameObject.layer));
		contactFilter.useLayerMask = true;

		curHealth = maxHealth;

		renderer = GetComponent<Renderer> ();

		canvas = GameObject.FindGameObjectWithTag ("Canvas").GetComponent<Canvas> ();


		gM = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<GameMaster> ();
	}

	void Update () 
	{
		targetVelocity = Vector2.zero;
		ComputeVelocity (); 

		if (curHealth > maxHealth) 
		{
			curHealth = maxHealth;
		}
		if (curHealth > 5) 
		{
			curHealth = 5;
		}
	
//		if (curHealth <= 0) 
//		{
//			Die ();
//		}
//


	}




	protected virtual void ComputeVelocity()
	{

	}

	void FixedUpdate()
	{
		velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
		velocity.x = targetVelocity.x;

		grounded = false;

		Vector2 deltaPosition = velocity * Time.deltaTime;

		Vector2 moveAlongGround = new Vector2 (groundNormal.y, -groundNormal.x);

		Vector2 move = moveAlongGround * deltaPosition.x;

		Movement (move, false);

		move = Vector2.up * deltaPosition.y;
		Movement (move, true);
		transform.localRotation = Quaternion.Euler(0,0,rotationZ);
		throws = false;



	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

	}

	void Movement(Vector2 move, bool yMovement)
	{
		float distance = move.magnitude;

		if (distance > minMoveDistance) 
		{
			int count = rb2d.Cast (move, contactFilter, hitBuffer, distance + shellRadius);
			hitBufferList.Clear ();
			for (int i = 0; i < count; i++) {
				hitBufferList.Add (hitBuffer [i]);
			}

			for (int i = 0; i < hitBufferList.Count; i++) 
			{
				Vector2 currentNormal = hitBufferList [i].normal;
				if (currentNormal.y > minGroundNormalY) 
				{
					grounded = true;
					if (yMovement) 
					{
						groundNormal = currentNormal;
						currentNormal.x = 0;
					}
				}

				float projection = Vector2.Dot (velocity, currentNormal);
				if (projection < 0) 
				{
					velocity = velocity - projection * currentNormal;
				}

				float modifiedDistance = hitBufferList [i].distance - shellRadius;
				distance = modifiedDistance < distance ? modifiedDistance : distance;
			}


		}

		rb2d.position = rb2d.position + move.normalized * distance;
	}

	void Die()
	{
		//Restart
	//	Application.LoadLevel (Application.loadedLevel);
	}

	public void Damage(int dmg)
	{
		curHealth -= dmg;
	}



}