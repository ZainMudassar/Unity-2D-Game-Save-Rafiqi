using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD1 : MonoBehaviour {


	public Sprite[] HeartSprites;
	public AudioClip playerDeath;

	public Image HeartUI;

	private Player player;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
	}

	void Update ()
	{
		HeartUI.sprite=HeartSprites[player.curHealth];
		if (player.curHealth == 0) 
		{
			
		}
	}


}
