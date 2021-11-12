using UnityEngine;
using System.Collections;

public class SpinningBlade : MonoBehaviour {
	public	Player player;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	void OnCollisionEnter2D(Collision2D Collision)
	{
		if( Collision.gameObject.tag == "Player" )
		{
			player.Damage(5);
	//		StartCoroutine(player.Knockback(0.02f,350,player.transform.position));
			Debug.Log("Collision");
			player.bladeDeath = true;

		}
	}
}
