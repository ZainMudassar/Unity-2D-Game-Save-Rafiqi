using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

	Player player;
	public int currentBananas = 0;
	PauseMenu pausePoint;
	GameObject[] banana;


	public  float percentage;
	public int number;

	private Text scoreText;

	public GameObject Star1, Star2, Star3;

	Scene currentScene;

	// Retrieve the name of this scene.
	public string sceneName;

	void Awake()
	{
//		number = banana.Length;

	}

	// Use this for initialization
	void Start ()
	{
		GameObject[] banana;
		banana = GameObject.FindGameObjectsWithTag ("Banana");
		number = banana.Length;
		currentBananas = GameMaster.banana;

		currentScene = SceneManager.GetActiveScene ();

		// Retrieve the name of this scene.
		sceneName = currentScene.name;

		if (banana.Length == 0) 
		{
			Debug.Log ("No game objects are tagged with fred");
		}
//
		scoreText = GetComponent<Text> ();

	
			Star1.SetActive (false);
			Star2.SetActive (false);
			Star3.SetActive (false);
		
			currentBananas = GameMaster.banana;

		if (sceneName == "Bonus Level") {
			scoreText.text = "You gathered" + currentBananas + " Bananas ";
		}
		else 
		{
			scoreText.text ="Score" + currentBananas + " / " + number;
			percentage = (currentBananas / number) * 100;
				
		}

	}
	
	// Update is called once per frame
	void Update ()
	{
//		banana = GameObject.FindGameObjectsWithTag ("Banana");
//		NoBananas = banana.Length;
//	
		currentBananas = GameMaster.banana;

		if (sceneName == "Bonus Level") 
		{
			scoreText.text = "You gathered" + currentBananas + " Bananas ";
		} 
		else
		{
			scoreText.text = currentBananas + " / " + number;
			percentage = (currentBananas / number) * 100;
		}

		if (percentage > 33 || percentage < 66) 
		{
			if (sceneName == "Bonus Level")
			{
				scoreText.text = currentBananas + " ";
			} 
			else
			{
				scoreText.text = currentBananas + " / " + number;
				Star1.SetActive (true);
				Star2.SetActive (false);
				Star3.SetActive (false);
			}
		}

		if (percentage > 66 || percentage < 99) 
		{
			if (sceneName == "Bonus Level") 
			{
				scoreText.text = currentBananas + " ";
			}
			else 
			{
				scoreText.text = currentBananas + " / " + number;
				Star1.SetActive (true);
				Star2.SetActive (true);
				Star3.SetActive (false);
			}
		}

		if (percentage > 99) 
		{
			if (sceneName == "Bonus Level") 
			{
				scoreText.text = currentBananas + " ";
			} 
			else 
			{
				scoreText.text = currentBananas + " / " + number;
				Star1.SetActive (true);
				Star2.SetActive (true);
				Star3.SetActive (true);
			}
		}
	}
}

