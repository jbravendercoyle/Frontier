using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BattleItemButton : MonoBehaviour {

	public GameObject Item;

	// Use this for initialization
	void Start () {
		Item = this.gameObject.transform.GetComponentInParent<BattleInventory> ().Item1GameObject;
		this.gameObject.GetComponent<Button> ().onClick.AddListener (() => addCallback());
	}
	
	// Update is called once per frame
	void addCallback () {
		GameObject playerParty = GameObject.Find ("PlayerParty");
		playerParty.GetComponent<SelectUnit> ().selectItem (Item);


	}
}
