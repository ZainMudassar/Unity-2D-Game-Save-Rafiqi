using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public float interpVelocity;
	public float minDistance;
	public float followDistance;
	public GameObject target;
	public Vector3 offset;
	Vector3 targetPos;
	float x,y;


	// Use this for initialization
	void Start () {
		targetPos = transform.position;
//		y = Camera.main.orthographicSize * 2.0;
//		x = y * Screen.width / Screen.height;
//		transform.localScale = new Vector3(x, y, 1);
		Camera.main.orthographicSize = 10;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (target)
		{
			Vector3 posNoZ = transform.position;
			posNoZ.z = target.transform.position.z;

			Vector3 targetDirection = (target.transform.position - posNoZ);

			interpVelocity = targetDirection.magnitude * 5f;

			targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime); 

			transform.position = Vector3.Lerp( transform.position, targetPos + offset, 0.25f);

		}
	}
}