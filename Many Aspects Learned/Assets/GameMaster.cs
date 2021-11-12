using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster: MonoBehaviour {

	[HideInInspector]
	public static  int banana,	stone, counterB;

//	public static int counterB=1;
	Player player;

	public  Text pointsText;
	public  Text pointsText2;


	// Use this for initialization
	void Start () {
		stone = Player.ammo;

		GameObject[] bananas;
		bananas = GameObject.FindGameObjectsWithTag ("Banana");


		counterB = bananas.Length;

		if (bananas.Length == 0) 
		{
			Debug.Log ("No game objects are tagged with fred");
		}
		//

		
	}
	
	// Update is called once per frame
	void Update ()
	{
		pointsText.text = ("Bananas: " + banana); //+ "\tStone: " + Player.ammo);
		pointsText2.text = ("Stone: " + Player.ammo);

		GameObject[] bananas;
		bananas = GameObject.FindGameObjectsWithTag ("Banana");

		counterB = bananas.Length;
	}
}
