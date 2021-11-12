using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {
	public Rigidbody2D rb2d;
	public float FallDelay;
//	private Transform platPos;
	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
//		platPos = rb2d.transform;
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.collider.CompareTag("Player"))
		{
			StartCoroutine(Fall());
		}
//		
	}

	IEnumerator Fall()
	{
		yield return new WaitForSeconds(FallDelay);
		rb2d.isKinematic = false;
		GetComponent<Collider2D>().isTrigger = true;
//		yield return new WaitForSeconds (3);
//		Instantiate (rb2d, platPos);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Water")) 
		{
			Destroy (gameObject);
//			Instantiate (gameObject, platPos);
		}
		if (col.CompareTag ("Ground")) 
		{
			Destroy (gameObject);
		}
	}
}
