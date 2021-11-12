using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesMove : MonoBehaviour {

	public Transform[] movePoints;
	int currentPoint;
	public float speed=0.5f;
	public float timestill=2f;
	public float sight=3f;

	// Use this for initialization
	void Start () {
		StartCoroutine ("MoveSpike");
		Physics2D.queriesStartInColliders = false;

	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit= Physics2D.Raycast (transform.position, transform.localScale.y * Vector2.up, sight);
	}

	IEnumerator MoveSpike()
	{
		while (true) 
		{
			if(transform.position.y== movePoints[currentPoint].position.y )
			{
				currentPoint++;
			}

			if(currentPoint >= movePoints.Length)
			{
				currentPoint=0;
			}

			transform.position=Vector2.MoveTowards(transform.position,new Vector2(movePoints[currentPoint].position.y,transform.position.y),speed);

			yield return null;
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;

		Gizmos.DrawLine (transform.position, transform.position + transform.localScale.y * Vector3.up * sight);

	}

}
