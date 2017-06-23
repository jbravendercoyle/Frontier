using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterPanel : MonoBehaviour {

    string UnitName;
    float HP;
    float maxHP;
    //Character Panel Children
    private Transform Child0;
    private Transform Child1;


    private GameObject Character;

    // Use this for initialization
    void Start() {
        Page1();
    }

    public void Page1()
    {
        UnitName = StartBattle.PartyManager.GetComponentInChildren<PlayerUnitAction>().unitName;
        HP = StartBattle.PartyManager.GetComponentInChildren<UnitStats>().HP;
        maxHP = StartBattle.PartyManager.GetComponentInChildren<UnitStats>().maxHP;

        Child0 = this.gameObject.transform.GetChild(0);
        Child1 = this.gameObject.transform.GetChild(1);

        Child0.GetComponent<Text>().text = UnitName;
        Child1.GetComponent<Text>().text = HP.ToString("N0") + "/" + maxHP.ToString("N0");
    }

    public void Page2()
    {

    }
}
