using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BattleItemButton : MonoBehaviour {

	public GameObject Item;
	private bool oneUse;
	private Button thisButton;

	// Use this for initialization
	void Start () {
		Item = this.gameObject.transform.GetComponentInParent<BattleInventory> ().Item1GameObject;
		this.gameObject.GetComponent<Button> ().onClick.AddListener (() => addCallback());
		thisButton = this.gameObject.GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void addCallback () {
		GameObject playerParty = GameObject.Find ("PlayerParty");
		playerParty.GetComponent<SelectUnit> ().selectItem (Item);
		oneUse = true;
	


	}

	void Update () {
		if (oneUse == true) {
			Item.gameObject.GetComponent<Potion> ().quantity -= 1;
			oneUse = false;

			if (Item.GetComponent<Potion> ().quantity == 0) {
				thisButton.interactable = false;
			}
		}
	}
	}
