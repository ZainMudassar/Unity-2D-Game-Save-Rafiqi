using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD1 : MonoBehaviour {

	private Player player;

	//public Sprite[] HeartSprites;
	public Sprite[] NewSprite;

	//public Image HeartUI;
	public Image NewHeart;

	AudioSource bruhSource;

	public AudioClip bruh;



	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player> ();
		bruhSource = GetComponent<AudioSource> ();
	}

	void Update ()
	{
		
//			HeartUI.sprite = HeartSprites [player.curHealth];
		if (player.curHealth <= 5 && player.curHealth >=0) 
		{
			NewHeart.sprite = NewSprite [player.curHealth];
		} 
		else if (player.curHealth<0)
		{
			player.curHealth = 0;
		}

		if (player.curHealth == 0) 
		{
			player.hurt = true;
			bruhSource.clip = bruh;
			bruhSource.Play ();
		}
			
		if (player.curHealth==0 && player.bladeDeath==true)
		{
			player.hurt=false;
			player.bladeDeath = true;
		}

	}


}
