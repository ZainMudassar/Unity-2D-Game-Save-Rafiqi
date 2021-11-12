using UnityEngine;
using System.Collections;

public class Kill : MonoBehaviour {
	public	Playerr player;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Playerr> ();
	}

	void OnCollisionEnter2D(Collision2D Collision)
	{
		if( Collision.gameObject.tag == "Player" )
		{
			player.Damage(1);
			StartCoroutine(player.Knockback(0.02f,350,player.transform.position));
			Debug.Log("Collision");
		}
	}
}
