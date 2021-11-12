using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Water : MonoBehaviour {

	public static float speed=0.3f;
	Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		transform.position += transform.up * speed * Time.deltaTime;
		
	}
//
//	public void Slow()
//	{
//		speed = 0.1f;
//		yield return new WaitForSeconds (2f);
//		speed = 0.4f;
//
//	}
}

// Special object to slow down the water level.
// platforms floating over the water