using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour 
{
	public GameObject PauseIU;
	TimeManager timer;
	public GameObject TimerUI;


	public bool paused = false;
	public string checks;

	void Start()
	{
		PauseIU.SetActive (false);
		TimerUI.SetActive (false);
	}

	void onEnable()
	{
		PauseIU.SetActive (false);
		TimerUI.SetActive (false);
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

	public void timerCheck()
	{
		if (timer.countingTime == 0) 
		{
			TimerUI.SetActive (true);
		Time.timeScale = 0;
			timer.ResetTime ();
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
	//	pauseCheck ("Pause");
		if(Input.GetButtonDown("Pause"))
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

	public void Resume()
	{
		paused = false; 
	}

	public void Restart()
	{
		Application.LoadLevel (Application.loadedLevel);
		timer.startingTime = 10;
	}

	public void MainMenu()
	{
		Application.LoadLevel (0);
		
	}


	public void Quit()
	{
		Application.Quit ();
	}

}
