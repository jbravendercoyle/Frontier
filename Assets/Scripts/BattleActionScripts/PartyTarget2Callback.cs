using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class PartyTarget2Callback : MonoBehaviour {


	void Start ()
	{

		this.gameObject.GetComponent<Button> ().onClick.AddListener (() => 
			selectPartyTarget ());

	}

	public void selectPartyTarget() {
		GameObject partyData = GameObject.Find ("PlayerParty");
		//needs to point to the playerUnit, hopefully through an owner pass on the frame in frame creation in PlayerUnitAction

		//Gets the instance for the second player's frame
		partyData.GetComponent<SelectUnit> ().actionPlayerTarget(StartBattle.PartyManager.transform.GetChild(1).gameObject);
	}
}	