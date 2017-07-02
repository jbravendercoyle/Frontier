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

		HUDCanvas = GameObject.Find ("HUDCanvas"); //Get HUDCanvas
		HUDCanvas = HUDCanvas.transform.GetChild (0).GetChild (3).transform.GetChild (0).gameObject; //Get "Panel" in ActionsMenu/ItemAction
		HUDCanvas.SetActive (true); //Open Battle Item Panel
		EventSystem.current.SetSelectedGameObject (HUDCanvas.transform.GetChild(0).gameObject); //Set the first Item as the highlighted button

		HUDopen = true;
		}
		

	void Update()
	{
		if (HUDopen && Input.GetButton("Cancel"))
			{
			HUDCanvas.SetActive (false);
			HUDopen = false;
			EventSystem.current.SetSelectedGameObject(BattleEventSystem.HighlightCommands.transform.GetChild(0).transform.GetChild (0).gameObject);
			}
	}
		
}