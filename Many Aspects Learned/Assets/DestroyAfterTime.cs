﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject.Destroy (gameObject, 3);
	}

	void OnCollisionEnter2d(Collision2D col)
	{
		if (col.collider.CompareTag ( "Player")) 
		{
			GameMaster.banana += 1;
			Destroy (gameObject);
		}
	}

}
