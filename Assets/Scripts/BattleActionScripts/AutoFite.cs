using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class AutoFite : MonoBehaviour {

	[SerializeField]
	private bool physical;


	private void Update() {
		GameObject playerParty = GameObject.Find ("PlayerParty");
		playerParty.GetComponent<SelectUnit> ().selectAttack (this.physical);
		//playerParty.GetComponent<SelectUnit> ().attackEnemyTarget (this.gameObject);
	}

}

