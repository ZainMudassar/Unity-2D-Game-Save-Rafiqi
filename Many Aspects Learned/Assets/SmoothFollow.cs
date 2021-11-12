using UnityEngine;
using System.Collections;

public class Camera2DFollow : MonoBehaviour {

	public Transform target;
	public float damping = 1;
	public float lookAheadFactor = 3;
	public float lookAheadReturnSpeed = 0.5f;
	public float lookAheadMoveThreshold = 0.1f;

	public GameObject boy;
	public Transform Cam;

	float offsetZ;
	Vector3 lastTargetPosition;
	Vector3 currentVelocity;
	Vector3 lookAheadPos;

	// Use this for initialization
	void Start () 
	{
		lastTargetPosition = target.position;
		offsetZ = (transform.position - target.position).z;
		transform.parent = null;
	}

	// Update is called once per frame
	void Update () 
	{
		this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x,3.898071f,this.gameObject.transform.position.z);
		// only update lookahead pos if accelerating or changed direction
		float xMoveDelta = (target.position - lastTargetPosition).x;

		boy.transform.Translate(0,0,0.4f);
		Cam.transform.position = new Vector3(Cam.transform.position.x,Cam.transform.position.y,boy.transform.position.z - 5);  

		bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

		if (updateLookAheadTarget) {
			lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
		} else {
			lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);    
		}

		Vector3 aheadTargetPos = target.position + lookAheadPos + Vector3.forward * offsetZ;
		Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping);

		transform.position = newPos;

		lastTargetPosition = target.position;        
	}
}