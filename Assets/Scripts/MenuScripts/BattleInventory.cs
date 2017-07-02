using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//Inventory for Battles

public class BattleInventory: MonoBehaviour {

	//Gets the Playerparty Inventory for Battle
		string ItemName;
		int quantity;

		private GameObject Inventory;
		private Transform Item1;//Item 1

		// Use this for initialization
		void Start () {
			Page1 ();
		}

		public void Page1()
		{ 
			//Find Player Inventory
			Inventory = StartBattle.PartyManager.transform.Find("Inventory").gameObject;

			//Get Items in Inventory
		ItemName = Inventory.transform.GetChild(0).gameObject.GetComponent<Potion>().ItemName;
		quantity = Inventory.transform.GetChild(0).gameObject.GetComponent<Potion> ().quantity;

			//Set Info in Inventory
			Item1 = this.gameObject.transform.GetChild(0).gameObject.transform;
			Item1.GetComponent<Text>().text = (ItemName + " " +quantity);
		}
	}