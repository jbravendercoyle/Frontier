using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class BattleEventSystem : MonoBehaviour {

	public static GameObject HighlightCommands;
	private bool waitingToSelect;

	// Use this for initialization
	void Start () {
		HighlightCommands = this.gameObject;
	}

	void onEnable() {
		EventSystem.current.SetSelectedGameObject (null);
		waitingToSelect = true;
	}

	void Update()
	{

		if (HighlightCommands.transform.GetChild (1).gameObject.activeSelf && !waitingToSelect) {

			EventSystem.current.SetSelectedGameObject (HighlightCommands.transform.GetChild (1).transform.GetChild (0).gameObject);
			waitingToSelect = true;

		}
		if (!HighlightCommands.transform.GetChild (1).gameObject.activeSelf && waitingToSelect) {
			
			EventSystem.current.SetSelectedGameObject (HighlightCommands.transform.GetChild (0).transform.GetChild (0).gameObject);
			waitingToSelect = false;
		}


	}
}
		