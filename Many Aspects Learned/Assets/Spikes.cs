using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

	private Player player;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
	}

	void OnTriggerStay2d(Collider2D col)
	{
		if (col.CompareTag ("Player")) 
		{
			player.Damage(3);
		//	StartCoroutine (player.Knockback (0.02f, 350, player.transform.position));
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
