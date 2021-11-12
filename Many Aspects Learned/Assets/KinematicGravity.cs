using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KinematicGravity : MonoBehaviour
{
//	public bool m_UseGravity;
	private Rigidbody2D body;

	void Start ()
	{    
		body = GetComponent<Rigidbody2D>();            
		body.bodyType = RigidbodyType2D.Kinematic;
	}

	void FixedUpdate()
	{
		if (body) //|| !m_UseGravity)
			return;

		body.velocity = body.velocity + (Physics2D.gravity * Time.fixedDeltaTime);
	}

//	void OnValidate()
//	{
//		if (body && !m_UseGravity)
//			body.velocity = Vector2.zero;
//	}
}
