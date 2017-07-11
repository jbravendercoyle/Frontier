using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BattleLevelUpMenu : MonoBehaviour {

	//first party member info
	string UnitName0;
	float Reward0;
	float CurrentXP0;

	//second party member info
	string UnitName1;
	float Reward1;
	float CurrentXP1;

	//second party member info
	string UnitName2;
	float Reward2;
	float CurrentXP2;

	//Enemy Reward
	public float xpPer;

	//Character Panel Children
	private Transform Child0; //UnitName0
	private Transform Child1; //Reward0
	private Transform Child2; //CurrentXP0

	private Transform Child3; //UnitName1
	private Transform Child4; //Reward1
	private Transform Child5; //CurrentXP1

	private Transform Child6; //UnitName2
	private Transform Child7; //Reward2
	private Transform Child8; //CurrentXP2

	//Party Children
	private Transform PartyMember0;
	private Transform PartyMember1;
	private Transform PartyMember2;

	private GameObject Character;

	// Use this for initialization
	void Start() {
		Page1(xpPer);
	}

	public void Page1(float xpPer)
	{

		//Get Party Member Units
		PartyMember0 = StartBattle.PartyManager.transform.GetChild (0);
		PartyMember1 = StartBattle.PartyManager.transform.GetChild (1); 
		PartyMember2 = StartBattle.PartyManager.transform.GetChild (2);



		// Get info for Unit 1
		UnitName0 = PartyMember0.GetComponent<PlayerUnitAction> ().unitName;
		Reward0 = PartyMember0.GetComponent<UnitStats> ().HP;
		CurrentXP0 = PartyMember0.GetComponent<UnitStats> ().currentExperience;

		// Get info for Unit 2
		if (PartyMember1 && PartyMember1.gameObject.name != ("Inventory")) {
			UnitName1 = PartyMember1.GetComponent<PlayerUnitAction> ().unitName;
			Reward1 = PartyMember1.GetComponent<UnitStats> ().HP;
			CurrentXP1 = PartyMember1.GetComponent<UnitStats> ().currentExperience;
		}

		// Get info for Unit 3
		if (PartyMember2 != null && PartyMember2.gameObject.name != ("Inventory")) {
			UnitName2 = PartyMember2.GetComponent<PlayerUnitAction>().unitName;
			Reward2 = PartyMember2.GetComponent<UnitStats>().HP;
			CurrentXP2 = PartyMember2.GetComponent<UnitStats>().currentExperience;
		}

		//get objects for first unit
		Child0 = this.gameObject.transform.GetChild (0);
		Child1 = this.gameObject.transform.GetChild (0).transform.GetChild(0).transform.GetChild(0);
		Child2 = this.gameObject.transform.GetChild (0).transform.GetChild(1).transform.GetChild(0);

		//get objects for second unit
		if (PartyMember1 && PartyMember1.gameObject.name != ("Inventory")) {
			Child3 = this.gameObject.transform.GetChild (1);
			Child4 = this.gameObject.transform.GetChild (1).transform.GetChild(0).transform.GetChild(0);
			Child5 = this.gameObject.transform.GetChild (1).transform.GetChild(1).transform.GetChild(0);
		}

		//get objects for third unit
		if (PartyMember2 && PartyMember2.gameObject.name != ("Inventory")) {
			Child6 = this.gameObject.transform.GetChild (2);
			Child7 = this.gameObject.transform.GetChild (2).transform.GetChild(0).transform.GetChild(0);
			Child8 = this.gameObject.transform.GetChild (2).transform.GetChild(1).transform.GetChild(0);
		}
		//Show Stats on Character  Panel
		//setting info for first unit
		Child0.GetComponent<Text> ().text = UnitName0;
		Child1.GetComponent<Text> ().text = xpPer.ToString("N0");
		Child2.GetComponent<Text> ().text = CurrentXP0.ToString ("N0"); 

		//sets info for second unit
		if (PartyMember1 && PartyMember1.gameObject.name != ("Inventory")) {
			Child3.GetComponent<Text> ().text = UnitName1;
		    Child4.GetComponent<Text> ().text = xpPer.ToString("N0");
			Child5.GetComponent<Text> ().text = CurrentXP1.ToString ("N0");
		}

		//set info for third unit
		if (PartyMember2 && PartyMember2.gameObject.name != ("Inventory") ) {
			Child6.GetComponent<Text> ().text = UnitName2;
			Child7.GetComponent<Text> ().text = xpPer.ToString("N0");
			Child8.GetComponent<Text> ().text = CurrentXP2.ToString ("N0");
		}
	}

	public void Page2()
	{

	}
}
