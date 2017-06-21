using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterPanel : MonoBehaviour {

    string UnitName;

    private GameObject Character;

    public GameObject PlayerParty;

    // Use this for initialization
    void Start () {
        this.PlayerParty = GameObject.Find("/MageUnit");
	}
	
	// Update is called once per frame
	void Update () {
        UnitName = this.PlayerParty.GetComponent<PlayerUnitAction>().unitName;

        this.gameObject.GetComponentInChildren<Text>().text = UnitName;
	}
}
