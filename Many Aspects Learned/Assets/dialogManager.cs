using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogManager : MonoBehaviour {

	public Text nameText;
	public Text dialogText;
	public LevelLoader LL;
	public int EndLevelIndex;
	private Queue<string> sentences;
	private string[] characterName;
	// Use this for initialization
	void Start () {
		sentences = new Queue<string> ();
		
	}
	public void StartDialog(dialog Dialog){
		Debug.Log ("Starting converstaion with" + Dialog.name);
		characterName = Dialog.name;
	//	string name = Dialog.name[0];

		sentences.Clear ();

	//	foreach (string sentence in Dialog.sentences) {
	//		nameText.text = name;

	//		sentences.Enqueue (sentence);
	//	}


		for (int i = 0; i < Dialog.sentences.Length; i++) {
//			if (i % 2 == 0) {
//				name = Dialog.name [0];
//			} else {
//				name = Dialog.name [1];
//			}
//			Debug.Log (i + " - " + name);
			sentences.Enqueue (Dialog.sentences[i]);
//			nameText.text = name;

		}
		DisplayNextSentence ();
	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0) {
			EndDialog ();
			return;
		}
		if (sentences.Count % 2 == 0) {
			nameText.text = characterName [1];
		} else {
			nameText.text = characterName [0];
		}
		string sentence = sentences.Dequeue();
		dialogText.text = sentence;

	}

	void EndDialog(){
		Debug.Log ("End of conversation.");
		LL.PlayGame (EndLevelIndex);
	}
}
