using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour 
{
	public GameObject PauseIU;
	public GameObject TimerUI;
	public GameObject DeathUI;
	public GameObject ControlUI;
	public GameObject SuccessUI;

	public	SpawnManager SpawnManagerObject;

	public	TimeManager timer;

	public Player player;

	GameObject[] banana;

	public bool paused = false;
	public string checks;

	Scene currentScene;

	// Retrieve the name of this scene.
	public string sceneName;

	finishPoint Fp;

	public static int NoOfBananas;

	void Start()
	{
		PauseIU.SetActive (false);
		TimerUI.SetActive (false);
		DeathUI.SetActive (false);
		SuccessUI.SetActive (false);


		currentScene = SceneManager.GetActiveScene ();

		// Retrieve the name of this scene.
		sceneName = currentScene.name;

		if (sceneName == "BonusLevel") 
		{
			// Do something...
		}
		else if (sceneName == "Example 2")
		{
			// Do something...
		}

	}

	void onEnable()
	{
		PauseIU.SetActive (false);
		TimerUI.SetActive (false);
		DeathUI.SetActive (false);
		SuccessUI.SetActive (false);
	}
	public void pauseCheck()
	{
		if(Input.GetKeyDown(KeyCode.P) || checks == "Pause")
		{
			paused = !paused;
		}
		if(paused)
		{
			PauseIU.SetActive(true);
			Time.timeScale = 0;
		}
		if(!paused)
		{
			PauseIU.SetActive(false);
			Time.timeScale = 1;
		}
	}

	public void doPause(string value)
	{
		if(value == "Pause")
		{
			paused = !paused;
		}
	}

	public void deathCheck()
	{
		if (player.curHealth == 0) 
		{	
			TimerUI.SetActive (false);
			ControlUI.SetActive (false);
			StartCoroutine(callDeathUI());
			player.stopPlayer (move:false);
		//	Time.timeScale = 0;
		} 
		else 
		{
			DeathUI.SetActive (false);
		//	Time.timeScale = 1;
		}
	}

	IEnumerator callDeathUI()
	{
		yield return new WaitForSeconds (2);
		DeathUI.SetActive (true);
	}

	public void successCheck()
	{
		if (SuccessUI.gameObject.activeSelf == true) 
		{
			DeathUI.gameObject.SetActive (false);
			ControlUI.gameObject.SetActive (false);
			TimerUI.gameObject.SetActive (false);
		}
	}

	public void timerCheck()
	{
		if (timer.countingTime == 0) 
		{
			ControlUI.SetActive (false);
			if  (sceneName == "Bonus Level") 
			{
				DeathUI.SetActive (false);
				TimerUI.SetActive (false);
				ControlUI.SetActive (false);
				SuccessUI.SetActive (true);
				Time.timeScale = 0;
			}
			else 
			{
				DeathUI.SetActive (false);
				ControlUI.SetActive (false);
				TimerUI.SetActive (true);
				Time.timeScale = 0;
			}
		} 
		else 
		{
			TimerUI.SetActive (false);
			Time.timeScale = 1;
		}
	}


	 void Update()
	{

		pauseCheck ();
		timerCheck ();
		FreezeTime ();
		deathCheck ();
		successCheck ();


	//	pauseCheck ("Pause");
		if(Input.GetButtonDown("Pause"))
		{
			paused = !paused;
		}

		if(paused)
		{
			PauseIU.SetActive(true);
			ControlUI.SetActive (false);
			DeathUI.SetActive (false);
			TimerUI.SetActive (false);
			Time.timeScale = 0;
		}
		if(!paused)
		{
		//	ControlUI.SetActive (true);
			PauseIU.SetActive(false);
			Time.timeScale = 1;
		}
	}

	public void Resume()
	{
		paused = false;
		ControlUI.SetActive (true);
	}

	public void Restart()
	{
		Application.LoadLevel (Application.loadedLevel);
		timer.startingTime = 10;
		GameMaster.banana = 0;
		GameMaster.stone = 0;
	}

	public void MainMenu()
	{
		Application.LoadLevel (0);
		
	}

	public void FreezeTime()
	{
		Time.timeScale = 0;
	}


	public void Quit()
	{
		Application.Quit ();
	}

}
