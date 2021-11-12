using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour {

	public CharacterController controller;
	public AudioClip[] grass;
	public AudioSource audio;

	private bool step = true;
	float audioStepLengthRun = 0.25f;

	void  OnControllerColliderHit ( ControllerColliderHit hit)
	{
		if (controller.isGrounded && controller.velocity.magnitude > 8 && hit.gameObject.tag == "Grass" && step == true) 
		{
			RunOnGrass (); 
		}
	}

	IEnumerator WaitForFootSteps(float stepsLength) 
	{
		step = false; 
		yield return new WaitForSeconds(stepsLength); 
		step = true;
	} 

	void RunOnGrass()
	{
		audio.clip = grass[Random.Range(0, grass.Length)];
		audio.volume = 0.3f;
		audio.Play();
		StartCoroutine(WaitForFootSteps(audioStepLengthRun));
	}

	// Use this for initialization
	void Start ()
	{

		AudioSource audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
