using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonSettings : MonoBehaviour {

	public static int releasedLevelStatic = 3;
	public int releasedLevel;
	public string nextLevel;
	// Use this for initialization

	void Awake()
	{
		if(PlayerPrefs.HasKey("Levels")){

			releasedLevelStatic = PlayerPrefs.GetInt ("Level,releasedlevelStatic");
		}
	}
	public void ButtonNextLevel()
	{
		SceneManager.LoadScene (nextLevel);
		if(releasedLevelStatic<=releasedLevel)
		{
			releasedLevelStatic = releasedLevel;
			PlayerPrefs.SetInt ("Level", releasedLevelStatic);
		}
	}
	public void ButtonMenu()
	{

		SceneManager.LoadScene ("MenuLevel");
	}
}
