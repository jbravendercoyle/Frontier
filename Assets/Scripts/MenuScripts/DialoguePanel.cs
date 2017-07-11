using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePanel : MonoBehaviour {

	public GameObject thisDialogue;
	public string nameOfSpeaker;
	public string line1;


	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {

			ShowDialogue();
		}
	}

	void OnTriggerExit2D(Collider2D other) {

		thisDialogue.SetActive (false);
		}


	public void ShowDialogue() {		

			thisDialogue.SetActive (true);
			thisDialogue.transform.GetChild (0).transform.GetChild(0).gameObject.GetComponent<Text> ().text = nameOfSpeaker;
			thisDialogue.transform.GetChild (0).transform.GetChild(1).gameObject.GetComponent<Text> ().text = line1;

		}
}
