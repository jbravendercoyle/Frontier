﻿using System.Collections;
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

    //Character Panel Children
    private Transform Child0; //UnitName
    private Transform Child1; //UnitHP
    private Transform Child2; //Level

    private Transform Child3; //UnitName2
    private Transform Child4; //UnitHP2
    private Transform Child5; //Level2

    //Party Children
    private Transform PartyMember0;
    private Transform PartyMember1;


    private GameObject Character;

    // Use this for initialization
    void Start() {
        Page1();
    }

    public void Page1()
    {

        PartyMember0 = StartBattle.PartyManager.transform.GetChild(0);
        PartyMember1 = StartBattle.PartyManager.transform.GetChild(1);

        UnitName = PartyMember0.GetComponent<PlayerUnitAction>().unitName;
        HP = PartyMember0.GetComponent<UnitStats>().HP;
        maxHP = PartyMember0.GetComponent<UnitStats>().maxHP;
        Level = PartyMember0.GetComponent<UnitStats>().level;

        UnitName2 = PartyMember1.GetComponent<PlayerUnitAction>().unitName;
        HP2 = PartyMember1.GetComponent<UnitStats>().HP;
        maxHP2 = PartyMember1.GetComponent<UnitStats>().maxHP;
        Level2 = PartyMember1.GetComponent<UnitStats>().level;

        Child0 = this.gameObject.transform.GetChild(0);
        Child1 = this.gameObject.transform.GetChild(1);
        Child2 = this.gameObject.transform.GetChild(2);
        Child3 = this.gameObject.transform.GetChild(3);
        Child4 = this.gameObject.transform.GetChild(4);
        Child5 = this.gameObject.transform.GetChild(5);

        //setting info for first unit
        Child0.GetComponent<Text>().text = UnitName;
        Child1.GetComponent<Text>().text = HP.ToString("N0") + "/" + maxHP.ToString("N0");
        Child2.GetComponent<Text>().text = "XP " + Level.ToString("N0"); 

        //sets info for second unit
        Child3.GetComponent<Text>().text = UnitName2;
        Child4.GetComponent<Text>().text = HP2.ToString("N0") + "/" + maxHP2.ToString("N0");
        Child5.GetComponent<Text>().text = "XP " + Level2.ToString("N0");
    }

    public void Page2()
    {

    }
}
