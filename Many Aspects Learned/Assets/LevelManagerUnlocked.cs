using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagerUnlocked : MonoBehaviour {

	public int Level;
	public Image Image;
	private string LevelString;

	// Use this for initialization
	void Start () {

		if (ButtonSettings.releasedLevelStatic >= Level) {
			Levelunlocked();

		} else {
			Levellocked();
		}
	}

	public void LevelSelect(string _level)
	{
		LevelString = _level;
		SceneManager.LoadScene (LevelString);
	}


	 void Levellocked()
	{
		GetComponent<Button> ().interactable = false;
		Image.enabled = true;
	}

	void Levelunlocked(){
		GetComponent<Button> ().interactable = true;
		Image.enabled = false;
	}
	// Update is called once per frame

}
