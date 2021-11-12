using System.Collections;
using UnityEngine.UI;
using UnityEngine;


public class TimeManager : MonoBehaviour {

	public float startingTime=10;
	public float countingTime;
	public GameObject TimerUI;
//
	private Text theText;
//
	private PauseMenu thePauseMenu;
//	// Use this for initialization
	void Start () {
		
		countingTime = startingTime;
		theText = GetComponent<Text>();

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
			TimerUI.gameObject.SetActive (true);
		
			Time.timeScale = 0;
	//		ResetTime ();
		} 
		else 
		{
			TimerUI.gameObject.SetActive (false);
			Time.timeScale = 1;
		}
	}

}
