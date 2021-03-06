using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MainClasss {

//	public bool OnLadder { get; set; }
	public AudioClip bananaSound;
//	public AudioSource audiosource;
	public AudioClip stoneSound;

	//public bool moveCheck = false;
	private float direction;
	private bool move, jumpBool;

	public bool bladeDeath = false;
	public float maxSpeed = 7;
	public float jumpTakeOffSpeed = 7;
	public float thrust=5;
	public AudioClip playerJump;
//	private bool facingRight;
	public AudioClip playerDeath;
	public static int ammo=5;

	[SerializeField]
	private GameObject knifePrefab;

	AudioSource playerAS;

	private SpriteRenderer spriteRenderer;
	private Animator animator;
//	[SerializeField]
//	private float climbSpeed;

	Vector2 player_direction;


	// Use this for initialization
	void Start()
	{
		playerAS = GetComponent<AudioSource>();
		water = GetComponent<Water> ();
		hurt = false;
		animator.SetBool ("blade", bladeDeath);


	}
	void Awake () 
	{

		spriteRenderer = GetComponent<SpriteRenderer> (); 
		animator = GetComponent<Animator> ();
	

	}


	void update()
	{

		if (curHealth==1)
		{

//			playerAS.clip = playerDeath;
//			playerAS.Play();
		}
		if (curHealth <= 0) 
		{
			Die ();

			playerAS.clip = playerDeath;
			playerAS.Play();
		}
		if (curHealth <= 0) 
		{
			curHealth = 0;
		}

		if (curHealth == 0) 
		{
			Time.timeScale = 0;
		}
	
	}
	private void HandleInput()
	{
		if (Input.GetKeyDown (KeyCode.V) && ammo>0) 
		{
			animator.SetBool ("throw",true);
			ThrowKnife(1);
			ammo -= 1;
			StartCoroutine (resetTrigger ());
		}



			
	}
	public void BtnJump()
	{
		animator.SetTrigger ("jump");

	}


	public void jumpTest(string value)
	{

		if ((Input.GetKeyDown (KeyCode.Space) || value == "jump") && grounded) 
		{
			velocity.y = jumpTakeOffSpeed;

			playerAS.clip = playerJump;
			playerAS.Play();

		}

	}

	protected override void ComputeVelocity()
	{
		Vector2 move = Vector2.zero;
		float x=Input.GetAxis("Horizontal");
		if (this.move) 
		{
			
			move.x = this.direction * Time.deltaTime; //Input.GetAxis ("Horizontal");
			if (x > 0f) 
			{
				transform.localScale = new Vector3 (1f, 1f, 1f);
			} 
			else if (x < 0f) 
			{
				transform.localScale = new Vector3 (-1f, 1f, 1f);
			}
			bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
			if (flipSprite) 
			{
				spriteRenderer.flipX = !spriteRenderer.flipX;
			}
		}

		if (jumpBool) {
			jumpTest ("jump");
		}
//		Debug.Log ("move : " +move.x);
		 

		if (curHealth==0)
		{

			playerAS.clip = playerDeath;
			playerAS.Play();

		}

		animator.SetBool ("grounded", grounded);
		animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maxSpeed);
				animator.SetBool ("throw", throws);
		animator.SetBool ("hurt", hurt);


		targetVelocity = move * maxSpeed;

		if (Input.GetKeyDown (KeyCode.V) && ammo>0) 
		{
			animator.SetBool ("throw",true);
			ThrowKnife(1);
			ammo -= 1;
			StartCoroutine (resetTrigger());
		}
	
	}


	public void stopPlayer(bool move){
		this.move = move;
	}

	public void stopJump(bool jump){
		this.jumpBool = jump;
	}

	public void movePlayer(int direction){
		this.direction = direction;
		this.move = true;


		animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maxSpeed);


	}



	void Die()
	{
		Application.LoadLevel (Application.loadedLevel);
		ammo = 5;
		GameMaster.banana = 0;

		playerAS.clip = playerDeath;
		playerAS.Play();
		//Application.LoadLevel (Application.loadedLevel);
	}


	void OnCollisionStay2D (Collision2D hit) 
	{ 
		if (hit.gameObject.tag == "MovePlatform") 
		{
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
		//	StartCoroutine(DieAndRespawn()); 
			StartCoroutine(Knockback(0,350,transform.position));
			curHealth -= 1;
			rb2d.AddForce(transform.up * thrust);
		}

		if (other.collider.CompareTag ("SpinningBlade")) 
		{	
			animator.SetBool ("hurt", false);
			animator.SetTrigger ("blade");
			curHealth = 0;
			bladeDeath = true;
			animator.SetBool ("hurt", false);
		}
		
		if (other.collider.CompareTag ("Enemy")) 
		{
//			StartCoroutine(DieAndRespawn()); 
			StartCoroutine (Knockback (0.2f, 350, transform.position));
		}
		if (other.collider.CompareTag("Water"))
		{
			//			StartCoroutine(DieAndRespawn());
			Die();
		}
		if (other.collider.CompareTag("TutorialHyena")) 
		{
			curHealth = 0;
		}
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
			GameMaster.banana += 1;
			Destroy (col.gameObject);
			playerAS.clip = bananaSound;
			playerAS.Play();
		}
		if (col.CompareTag ("Water")) 
		{
			Die();
		}
		if (col.CompareTag ("Mushroom"))
		{
			Destroy (col.gameObject);
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
		if (col.CompareTag("FullPoison"))
		{
			Destroy (col.gameObject);
			curHealth = 0;
		}
		if (col.CompareTag ("FullPotion")) 
		{
			Destroy (col.gameObject);
			curHealth = 5;
		}
	}

	public void ThrowKnife(int value)
	{
		if (direction > 0f) 
		{
		    GameObject tmp =  (GameObject) Instantiate (knifePrefab, transform.position, Quaternion.Euler(new Vector3(0,0,0)));
			tmp.GetComponent<Bullet> ().Initialize (Vector2.right);
		} 
		else if (direction < 0f)
		{
			GameObject tmp =  (GameObject) Instantiate (knifePrefab, transform.position, Quaternion.Euler(new Vector3(0,0,180)));
			tmp.GetComponent<Bullet> ().Initialize (Vector2.left);
		}
	}

	public IEnumerator Slow()
	{
		Water.speed = 0.1f;
		yield return new WaitForSeconds (10);
		Water.speed = 0.5f;
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

	public IEnumerator resetTrigger()
	{
	yield return new WaitForSeconds(5);
	animator.SetBool ("throw",false);
	}

} 
