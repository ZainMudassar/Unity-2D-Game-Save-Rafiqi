using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingsPlatform : MonoBehaviour {

	private Rigidbody2D rb2d;
	private BoxCollider2D boxcollider;

	public float fallplat;

	public float fallplaton;

	public bool isFalling = false;

	public Vector2 initialposition;

	private void Awake()
	{
		rb2d = GetComponent<Rigidbody2D>();
		boxcollider = GetComponent<BoxCollider2D>();
	}

	private void Start()
	{
		initialposition = transform.position;
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag("Player"))
		{
			Invoke("Fall", fallplat);
		}
	}

	void Fall()
	{
		rb2d.isKinematic = false;
		boxcollider.isTrigger = true;
		isFalling = true;
	}

	void respawn()
	{
		StartCoroutine(respawnco());
	}

	IEnumerator respawnco()
	{
		yield return new WaitForSeconds(fallplaton);
		isFalling = false;
		rb2d.isKinematic = true;
		boxcollider.isTrigger = false;
		transform.position = initialposition;
		rb2d.velocity = Vector2.zero;
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Death")

		{
			rb2d.isKinematic = true;
			boxcollider.isTrigger = false;
			isFalling = false;
			respawn();
		}
	}
}
