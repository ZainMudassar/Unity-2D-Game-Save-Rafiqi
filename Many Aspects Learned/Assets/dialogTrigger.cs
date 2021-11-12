using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogTrigger : MonoBehaviour {

	public dialog Dialog;

	public void TriggerDialog (){


		FindObjectOfType<dialogManager> ().StartDialog (Dialog);
	}
}
