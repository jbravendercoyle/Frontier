using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BattleItemActionCallback : MonoBehaviour {

	private GameObject HUDCanvas;
	bool HUDopen;

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<Button> ().onClick.AddListener (() => addCallback());

	}
	
	// Update is called once per frame
		private void addCallback() {

		HUDCanvas = GameObject.Find ("HUDCanvas");
		HUDCanvas = HUDCanvas.transform.GetChild (0).GetChild (3).transform.GetChild (0).gameObject;

		HUDCanvas.SetActive (true);
		HUDopen = true;
		}
		

	void Update()
	{
		//OpenCloseItemPanel ();
	}
		
}