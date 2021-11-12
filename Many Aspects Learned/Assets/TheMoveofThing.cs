
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Proxy - MovingPhysicsPlatform Script v1.0

public class TheMoveofThing : MonoBehaviour
{

public Vector2 moveDistance = new Vector2(2f,0); //How far in Units we want to go in X/Y.
public float moveSpeed = 5f;                    //Self explanatory
public float waitDuration = 1.5f;   
	public Transform transformB;
	Rigidbody2D rb2d;
	//How long to sit still at goal, before going back in other direction

private Vector2 startPos;
private int direction = 1;
private float goalDistance;

void Start()
{
	startPos = transformB.position;          //Store our starting position so we can check for when we've returned to this position
	goalDistance = 0.006f + (moveSpeed * 0.008f);   //Always have a goal distance of at least 0.006, for when our platforms are going very slow, but also increase the acceptable distance for goal based on move speed.
		rb2d = GetComponent<Rigidbody2D>();
}

void FixedUpdate()
{
//		if( direction == (transform.localScale = new Vector3 (1f, 1f, 1f)) (Vector2.Distance(transform.position, startPos + moveDistance) < goalDistance ) ) //If the Distance between our current position and the position we wanted to reach is less than the goalDistance, change direction and wait if waitDuration set
	{
		StartCoroutine( ChangeDir() );  //Start our wait/change direction Coroutine once we hit goal
	}
//		else if( direction == (transform.localScale = new Vector3 (-1f, 1f, 1f))  (Vector2.Distance(transform.position, startPos) < goalDistance ) )  //Same as before, just with our stored startPosition. And only if we're moving in the opposite direction, as to not trigger this as the start of movement, only when heading towards startPos.
	{
		StartCoroutine( ChangeDir() );
	}
		rb2d.velocity =  (moveSpeed * moveDistance.normalized) * direction; //Normalize our moveDistance to a 0-1 range so our set speed is consistent no matter how far the distance, and multiply it by moveSpeed and the direction we want to go.
}

IEnumerator ChangeDir()             //Delay for once our platform hits it's goal, if we want one. Most games tend to, it gives the player a better chance to get on...
{
	direction *= -1;                                //change the direction since we're going to reverse
	float lastMoveSpeed = moveSpeed;                //store the moveSpeed temporarily
	moveSpeed = 0;                                  //and set the actual moveSpeed to 0 so it doesn't move
	yield return new WaitForSeconds(waitDuration);  //Wait for how long we choose
	moveSpeed = lastMoveSpeed;                      //start moving again
}
}