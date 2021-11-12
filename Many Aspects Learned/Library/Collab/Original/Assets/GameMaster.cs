using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster: MonoBehaviour {

	[HideInInspector]
	public static  int banana,	stone;

	public  Text pointsText;
	public  Text pointsText2;

	// Use this for initialization
	void Start () {
		stone = Player.ammo;
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		pointsText.text = ("Bananas: " + banana); //+ "\tStone: " + Player.ammo);
		pointsText2.text = ("Stone: " + Player.ammo);

	}
}
