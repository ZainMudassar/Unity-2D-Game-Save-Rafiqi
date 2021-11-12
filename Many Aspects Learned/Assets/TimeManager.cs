using System.Collections;
using UnityEngine.UI;
using UnityEngine;


public class TimeManager : MonoBehaviour {

	public float startingTime=10;
	public float countingTime;
	public GameObject TimerUI;
//
	private TextMesh theText;
//
	private PauseMenu thePauseMenu;
//	// Use this for initialization
	void Start () {
		
		countingTime = startingTime;
		theText = GetComponent<TextMesh>();

//
		thePauseMenu = FindObjectOfType<PauseMenu>();
//
	}
//	
//	// Update is called once per frame
	void Update () {
		timerCheck ();
  	if (thePauseMenu.paused)
			return;
		countingTime -= Time.deltaTime;

		if (countingTime < 0) 
		{
			countingTime = 0;
		}
		theText.text = "" + Mathf.Round (countingTime); 
	}
	public void ResetTime()
	{
		countingTime = startingTime;
	}

	public void timerCheck()
	{
		if (countingTime == 0) 
		{
			if (thePauseMenu.sceneName == "Bonus Level") {
				TimerUI.gameObject.SetActive (false);
				thePauseMenu.ControlUI.SetActive (false);
				thePauseMenu.SuccessUI.SetActive (true);
			} else 
			{
				TimerUI.gameObject.SetActive (true);
				thePauseMenu.ControlUI.SetActive (false);
			}
					//	Time.timeScale = 0;
		} 
		else 
		{
			TimerUI.gameObject.SetActive (false);
		//	Time.timeScale = 1;
		}
	}

}
