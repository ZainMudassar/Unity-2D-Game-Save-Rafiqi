using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
	

	public TimeManager Tm;

	public bool CheckForBonusLevel;

	public GameObject RandomObject;

	public Transform spawnPosition;

	public GameObject target;

	public int counter;

	public float TimeCounterCheck;

	// Use this for initialization
	void Start () {
		CheckForBonusLevel = false;
		counter = 5;
		
	}
	
	// Update is called once per frame
	void Update () {
	//	StartCoroutine (SpawnObject ());
	//	CreateObject ();
		if (counter > 0) 
		{
		//	Invoke ("CreateObject", 5);

			InvokeRepeating("SpawnMyObject", 2, 1);
			counter --;
			CheckForBonusLevel = true;
		}
		TimeCounterCheck = Tm.countingTime;
		if (TimeCounterCheck<=2) 
		{
			CancelInvoke ("SpawnMyObject");
			Debug.Log ("Cancelled the invoke");
		}
			if (counter < 0) 
		{
			counter = 0;
		}

	}

	void CreateObject()
	{
		float range = Random.Range(-30,30 + 1);
		Instantiate(RandomObject, new Vector3(range,10,10), transform.rotation);
	}



	void SpawnMyObject()
	{
		float x = Random.Range(-16.0f, 16.0f);
		float z = Random.Range(-16.0f, 16.0f);
		Instantiate(target, new Vector3(x, 20, z), Quaternion.identity);
	}
}
