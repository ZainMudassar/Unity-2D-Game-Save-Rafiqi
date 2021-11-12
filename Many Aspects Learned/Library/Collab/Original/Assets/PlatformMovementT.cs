using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {

	private Vector3 posA;
	private Vector3 posB;
	private Vector3 nextPos;

	private Rigidbody2D rb2d;

	[SerializeField]
	public float speed;

	public Transform childTransform;

	[SerializeField]
	public Transform transformB;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		posA = childTransform.localPosition;
		posB = transformB.localPosition;
		nextPos = posB;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Move ();
	}	 
	//	OnTriggerStay (Collider2D other)
	//	{

	//		if(other.gameObject.tag == "platform"){
	//			transform.parent = other.transform;

	//		}
	//	}

	//	function OnTriggerExit(other:Collider)
	//	{
	//		if(other.gameObject.tag == "platform")
	//		{
	//			transform.parent = null;
	//		}
	//	}


	private void Move()
	{
		childTransform.localPosition = Vector3.MoveTowards (childTransform.localPosition, nextPos, speed * Time.deltaTime);
		if (Vector3.Distance (childTransform.localPosition, nextPos) <= 0.1) 
		{
			ChangeDestination ();
		}
	}

	private void ChangeDestination()
	{
		nextPos = nextPos != posA ? posA : posB;
	}
}
