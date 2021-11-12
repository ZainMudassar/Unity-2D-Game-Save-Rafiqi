using UnityEngine;
using System.Collections;

public class Kill : MonoBehaviour {
	public	Player player;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	void OnCollisionEnter(Collision2D collision)
	{
		if( collision.gameObject.tag == "Player" )
		{
			player.Damage(1);
			Destroy(collision.gameObject);
		}
	}
}
