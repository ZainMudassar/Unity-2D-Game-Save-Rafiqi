using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeParent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay2D (Collision2D other) 
	{ 
		{
			if (other.gameObject.tag=="MovePlatform")
				other.transform.parent = gameObject.transform; 
		}
	}
		
	void OnCollisionExit2D (Collision2D hit)
	{		
		{
			gameObject.transform.parent = null;
		}
	}

}
