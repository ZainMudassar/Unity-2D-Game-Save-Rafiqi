using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class Playerr : MainClasss {

	public float maxSpeed = 7;
	public float jumpTakeOffSpeed = 10;

	[SerializeField]
	private GameObject knifePrefab;
	public static int ammo=5;


	public GUILayer guiLeft, guiRight, guiJump;
	private SpriteRenderer spriteRenderer;
	private Animator animator;


	Vector2 player_direction;
//	public	int JumpMultiplier, speedMultiplier;
	Vector2 move;

	// Use this for initialization

	void start()
	{
		water = GetComponent<Water> ();
	
		hurt = false;
	
	}

	void Awake () 
	{
		spriteRenderer = GetComponent<SpriteRenderer> (); 
		animator = GetComponent<Animator> ();
	}


	void update()
	{
		if (curHealth <= 0) 
		{
			Die ();
		}
		if (curHealth <= 0) 
		{
			Die ();
		}
		if (curHealth <= 0) 
		{
			curHealth = 0;
		}
	
		float pointer_x = Input.GetAxis("Mouse X");
		float pointer_y = Input.GetAxis("Mouse Y");
		if (Input.touchCount > 0)
		{
			pointer_x = Input.touches[0].deltaPosition.x;
			pointer_y = Input.touches[0].deltaPosition.y;
		}
		{
			//If the Space button is pressed, the GameObject can jump
			if (Input.GetKeyDown(KeyCode.V))
				throws = true;

			//Otherwise the GameObject cannot jump.
			else throws = false;

			//If the GameObject is not jumping, send that the Boolean “Jump” is false to the Animator. The jump animation does not play.
			if (throws == false)
				animator.SetBool("throw", false);

			//The GameObject is jumping, so send the Boolean as enabled to the Animator. The jump animation plays.
			if (throws == true)
				animator.SetBool("throw", true);
		}
	}


	void jump()
	{
		if (Input.GetButtonDown ("Jump") && grounded) {
			velocity.y = jumpTakeOffSpeed;
		}

		else if (Input.GetButtonUp ("Jump")) 
		{
			if (velocity.y > 0) {
				velocity.y = velocity.y * 0.5f;
			}
		}
	}

	public void TheMoves()
	{
		
	}

	protected override void ComputeVelocity()
	{
		move = Vector2.zero;

		move.x = Input.GetAxis ("Horizontal");

		float x = Input.GetAxis ("Horizontal");
	
		if (x > 0f) 
		{
			transform.localScale = new Vector3 (1f, 1f, 1f);
		} 
		else if (x < 0f) 
		{
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		}

		if (Input.touchCount > 0)
		{


			// Get the touch info
			Touch t = Input.GetTouch(0);
			if (t.phase == TouchPhase.Began)
			{
				// Are we touching the left arrow?
				if (guiLeft.HitTest(t.position) )
				{
					x = -1;
				}
				if (guiRight.HitTest(t.position))
				{
					x = 1;
				}
				           }            }
		else if (Input.GetMouseButtonDown (0)) {
			// Are we clicking the left arrow?
			if (guiLeft.HitTest (Input.mousePosition) ){
				x = -1;
			}
			if (guiRight.HitTest (Input.mousePosition) ){
				x = 1;
			}
			            } 
		else {
			x = Input.GetAxis ("Horizontal");
			}


		float pointer_x = Input.GetAxis("Mouse X");
		float pointer_y = Input.GetAxis("Mouse Y");
		if (Input.touchCount > 0)
		{
			pointer_x = Input.touches[0].deltaPosition.x;
			pointer_y = Input.touches[0].deltaPosition.y;
		}

		jump ();
//		if (Input.GetButtonDown ("Jump") && grounded) {
//			velocity.y = jumpTakeOffSpeed;
//		}
//
//		else if (Input.GetButtonUp ("Jump")) 
//		{
//			if (velocity.y > 0) {
//				velocity.y = velocity.y * 0.5f;
//			}
//		}
//		bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
//		if (flipSprite) 
//		{
//			spriteRenderer.flipX = !spriteRenderer.flipX;
//		}
//
		animator.SetBool ("grounded", grounded);
		animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maxSpeed);
//		animator.SetBool ("throw", throws);
		animator.SetBool ("hurt", hurt);
		if (x>0 || x<0)
		{
		//	audio.Play ();	
		}

		targetVelocity = move * maxSpeed;

		if (Input.GetKeyDown (KeyCode.V) && ammo > 0) {
//			animator.SetTrigger ("throw");
			ThrowKnife (1);
			ammo -= 1;
			resetTrigger ();
//			throws = true;
//			if(!animator.GetCurrentAnimatorStateInfo(0).IsName("RafiqiThrow"))
//			{
//				throws = false;
//			}

		}
	}

	public IEnumerator resetTrigger()
	{
		yield return new WaitForSeconds (1);
		animator.SetTrigger ("idle");
	}

	void HandleInput()
	{
		float x = Input.GetAxis ("Horizontal");
		player_direction = Vector2.right * x;
	}


	void Die()
	{
		Application.LoadLevel (Application.loadedLevel);
		ammo = 5;
		GameMaster.banana = 0;
	}


	void OnCollisionStay2D (Collision2D hit) { 
		if (hit.gameObject.tag == "MovePlatform") {
			gameObject.transform.parent = hit.transform; 
		}
	}

	void OnCollisionExit2D (Collision2D hit){
		if (hit.gameObject.tag == "MovePlatform")
		{
			gameObject.transform.parent = null;
		}
	}



	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.CompareTag ("Obstacle")) 
		{
			StartCoroutine(DieAndRespawn()); 
			//StartCoroutine (Knockback (0.2f, 350, transform.position ));
		}
		if (other.collider.CompareTag ("Enemy")) 
		{
			StartCoroutine(DieAndRespawn()); 
			StartCoroutine (Knockback (0.2f, 350, transform.position));
		}
		if (other.collider.CompareTag("Water"))
		{
//			StartCoroutine(DieAndRespawn());
			Die();
		}
//		if (other.gameObject.tag == "MovePlatform") 
//		{
//			gameObject.transform.parent = other.transform; 
//		}
//

	
	}
		



	IEnumerator DieAndRespawn() {
			renderer.enabled = false;
			yield return new WaitForSeconds(0f);
			transform.localPosition = new Vector3(-8, 4, 1);
			transform.rotation = Quaternion.identity;
			renderer.enabled = true;

		}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Banana")) 
		{
			Destroy (col.gameObject);
			GameMaster.banana += 1;
		}
		if (col.CompareTag ("Water")) 
		{
			Die();
		}
		if (col.CompareTag ("Mushroom"))
		{
			Destroy (col.gameObject);
		//	curHealth += 1;
			StartCoroutine(Slow());
		}
		if (col.CompareTag ("Stone")) 
		{
			GameMaster.stone += 1;
			ammo = ammo + 1;
			Destroy (col.gameObject);
			if (ammo > 5) 
			{
				ammo = 5;
			}
		}
		if (col.CompareTag ("Apple")) 
		{
			Destroy (col.gameObject);
			curHealth += 1;
		}
//		if (col.CompareTag ("Obstacle")) 
//		{
//			StartCoroutine (Knockback (0.02f,350,transform.position));
//		}
	}

	public IEnumerator Slow()
	{
		Water.speed = 0.1f;
		yield return new WaitForSeconds (10);
		Water.speed = 0.5f;
	}

	public void ThrowKnife(int value)
	{
		if (transform.localScale.x > 0) 
		{
			GameObject tmp = (GameObject)Instantiate (knifePrefab, transform.position, Quaternion.Euler (new Vector3 (5, 5, 0)));
			tmp.GetComponent<Bullet> ().Initialize (Vector2.right);
		}
		else if (transform.localScale.x < 0) 
		{
			GameObject tmp = (GameObject)Instantiate (knifePrefab, transform.position, Quaternion.Euler (new Vector3 (-5, -5, 180)));
			tmp.GetComponent<Bullet> ().Initialize (Vector2.left);
		}

	}



	public IEnumerator Knockback(float KnockDuration, float KnockBackPower, Vector3 KnockBackDirection)
	{
		float timer = 0;
		while (KnockDuration > timer)
		{
			timer+=Time.deltaTime;
			rb2d.AddForce(new Vector3 (KnockBackDirection.x * -100, KnockBackDirection.y * KnockBackPower, transform.position.z));

		}
		yield return 0;
	}

} 

		



