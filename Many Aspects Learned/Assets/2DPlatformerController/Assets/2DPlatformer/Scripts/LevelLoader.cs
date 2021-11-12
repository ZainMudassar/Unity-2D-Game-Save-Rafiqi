using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	public int LevelNumber;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void PlayGame(int LevelNumber)
	{
		SceneManager.LoadScene (LevelNumber);
		GameMaster.banana = 0;
		GameMaster.stone = 0;
		// SceneManager.GetSceneByBuildIndex (1);
	}


	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.CompareTag ("Player")) 
		{
			SceneManager.LoadScene (LevelNumber);
		}
	}
}