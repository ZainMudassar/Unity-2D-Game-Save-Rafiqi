 using System.Collections;
using UnityEngine;

public class FallingPlatformM : MonoBehaviour {


	private Rigidbody2D rb2d;
	public GameObject platformPrefab;
	public float FallDelay;
	public float showDelay;
	public GameObject platform;
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
			StartCoroutine(showRespawned());


		}
	}

	IEnumerator Fall()
	{
		yield return new WaitForSeconds(FallDelay);
		platform = Instantiate(platformPrefab, transform.position, transform.rotation);
		platform.SetActive (false);

		rb2d.isKinematic = false;
		GetComponent<Collider2D>().isTrigger = true;
		//GameObject.Destroy (gameObject, 5);
		//		yield return new WaitForSeconds (3);
		//		Instantiate (rb2d, platPos);
	}

	IEnumerator showRespawned()
	{
		Debug.Log ("in respawn");
		yield return new WaitForSeconds(showDelay);

		Debug.Log (platform);

		platform.SetActive (true);
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
// save position