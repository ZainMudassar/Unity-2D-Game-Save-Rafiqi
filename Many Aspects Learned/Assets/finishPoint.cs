using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishPoint : MonoBehaviour {

	Player player;

	private TextMesh scoreText;
	public bool pause;

	public GameObject NextUI;
	public PauseMenu Pm;

	public TimeManager timer;


	// Use this for initialization
	void Start () {
		NextUI.SetActive (false);
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) 
		{
			NextUI.SetActive (true);
			Time.timeScale = 0;
			Pm.FreezeTime ();
			timer.ResetTime ();
		}
	}
}
