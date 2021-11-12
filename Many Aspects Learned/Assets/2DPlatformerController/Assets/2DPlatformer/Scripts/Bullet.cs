using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
	[SerializeField]
	private float speed;


	private Rigidbody2D myRigidbody;

	private Vector2 direction;
	// Use this for initialization
	void Start () 
	{
		myRigidbody = GetComponent<Rigidbody2D>();


	}

	void FixedUpdate()
	{
		myRigidbody.velocity = direction * speed;  
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (gameObject, 4);
		
	}
	public void Initialize(Vector2 direction)
	{
		this.direction = direction;
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Enemy")) 
		{
			Destroy (col.gameObject);
			Destroy (gameObject);
		}
		if (col.CompareTag ("TutorialHyena")) 
		{
			Destroy (col.gameObject);
			Destroy (gameObject);
		}
	}
}
