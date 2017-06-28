using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterPanel : MonoBehaviour {

    //first party member info
    string UnitName;
    float HP;
    float maxHP;
    float Level;

    //second party member info
    string UnitName2;
    float HP2;
    float maxHP2;
    float Level2;

	//second party member info
	string UnitName3;
	float HP3;
	float maxHP3;
	float Level3;

    //Character Panel Children
    private Transform Child0; //UnitName
    private Transform Child1; //UnitHP
    private Transform Child2; //Level

    private Transform Child3; //UnitName2
    private Transform Child4; //UnitHP2
    private Transform Child5; //Level2

	private Transform Child6; //UnitName3
	private Transform Child7; //UnitHP3
	private Transform Child8; //Level3

    //Party Children
    private Transform PartyMember0;
    private Transform PartyMember1;
	private Transform PartyMember2;

    private GameObject Character;

    // Use this for initialization
    void Start() {
        Page1();
    }

    public void Page1()
    {

		//Get Party Member Units
        PartyMember0 = StartBattle.PartyManager.transform.GetChild(0);
        PartyMember1 = StartBattle.PartyManager.transform.GetChild(1);
		PartyMember2 = StartBattle.PartyManager.transform.GetChild(2);

		// Get info for Unit 1
        UnitName = PartyMember0.GetComponent<PlayerUnitAction>().unitName;
        HP = PartyMember0.GetComponent<UnitStats>().HP;
        maxHP = PartyMember0.GetComponent<UnitStats>().maxHP;
        Level = PartyMember0.GetComponent<UnitStats>().level;

		// Get info for Unit 2
        UnitName2 = PartyMember1.GetComponent<PlayerUnitAction>().unitName;
        HP2 = PartyMember1.GetComponent<UnitStats>().HP;
        maxHP2 = PartyMember1.GetComponent<UnitStats>().maxHP;
        Level2 = PartyMember1.GetComponent<UnitStats>().level;

		// Get info for Unit 3
		UnitName3 = PartyMember2.GetComponent<PlayerUnitAction>().unitName;
		HP3 = PartyMember2.GetComponent<UnitStats>().HP;
		maxHP3 = PartyMember2.GetComponent<UnitStats>().maxHP;
		Level3 = PartyMember2.GetComponent<UnitStats>().level;

		//get objects for first unit
        Child0 = this.gameObject.transform.GetChild(0);
        Child1 = this.gameObject.transform.GetChild(1);
        Child2 = this.gameObject.transform.GetChild(2);

		//get objects for second unit
        Child3 = this.gameObject.transform.GetChild(3);
        Child4 = this.gameObject.transform.GetChild(4);
        Child5 = this.gameObject.transform.GetChild(5);

		//get objects for third unit
		Child6 = this.gameObject.transform.GetChild(6);
		Child7 = this.gameObject.transform.GetChild(7);
		Child8 = this.gameObject.transform.GetChild(8);

		//Show Stats on Character  Panel
        //setting info for first unit
        Child0.GetComponent<Text>().text = UnitName;
        Child1.GetComponent<Text>().text = HP.ToString("N0") + "/" + maxHP.ToString("N0");
        Child2.GetComponent<Text>().text = "XP " + Level.ToString("N0"); 

        //sets info for second unit
        Child3.GetComponent<Text>().text = UnitName2;
        Child4.GetComponent<Text>().text = HP2.ToString("N0") + "/" + maxHP2.ToString("N0");
        Child5.GetComponent<Text>().text = "XP " + Level2.ToString("N0");

		//set info for third unit
		Child6.GetComponent<Text>().text = UnitName3;
		Child7.GetComponent<Text>().text = HP3.ToString("N0") + "/" + maxHP3.ToString("N0");
		Child8.GetComponent<Text>().text = "XP " + Level3.ToString("N0");
    }

    public void Page2()
    {

    }
}
