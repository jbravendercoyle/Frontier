﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class TurnSystem : MonoBehaviour {

	private List<UnitStats> unitsStats;

	private GameObject playerParty;

	public GameObject enemyEncounter;

	//find xp per unit in collect unit reward and store it

	[SerializeField]
	private GameObject actionsMenu, enemyUnitsMenu, levelUpMenu;

    void Start() {
		this.playerParty = GameObject.Find ("PlayerParty");

		unitsStats = new List<UnitStats> ();
		GameObject[] playerUnits = GameObject.FindGameObjectsWithTag("PlayerUnit");
		foreach (GameObject playerUnit in playerUnits) {
			UnitStats currentUnitStats = playerUnit.GetComponent<UnitStats> ();
			currentUnitStats.calculateNextActTurn (0);
			unitsStats.Add (currentUnitStats);
		}
		GameObject[] enemyUnits = GameObject.FindGameObjectsWithTag("EnemyUnit");
		foreach (GameObject enemyUnit in enemyUnits) {
			UnitStats currentUnitStats = enemyUnit.GetComponent<UnitStats> ();
			currentUnitStats.calculateNextActTurn (0);
			unitsStats.Add (currentUnitStats);
		}
		unitsStats.Sort ();

		this.actionsMenu.SetActive (false);
		this.enemyUnitsMenu.SetActive (false);

		this.nextTurn ();
	}

	public void nextTurn() {
		GameObject[] remainingEnemyUnits = GameObject.FindGameObjectsWithTag ("EnemyUnit");
		//If Victory
		if (remainingEnemyUnits.Length == 0) {

			this.actionsMenu.SetActive (false);
			this.enemyUnitsMenu.SetActive (false);
			StartCoroutine(LevelUpPanel(levelUpMenu));
			SceneManager.LoadScene ("Main");


		}

		GameObject[] remainingPlayerUnits = GameObject.FindGameObjectsWithTag ("PlayerUnit");
		if (remainingPlayerUnits.Length == 0) {
			SceneManager.LoadScene ("Title");
		}

		UnitStats currentUnitStats = unitsStats [0];
		unitsStats.Remove (currentUnitStats);

		if (!currentUnitStats.isDead ()) {
			GameObject currentUnit = currentUnitStats.gameObject;

			currentUnitStats.calculateNextActTurn (currentUnitStats.nextActTurn);
			unitsStats.Add (currentUnitStats);
			unitsStats.Sort ();

			if (currentUnit.tag == "PlayerUnit") {
				this.playerParty.GetComponent<SelectUnit> ().selectCurrentUnit (currentUnit.gameObject);
				Debug.Log ("Player unit acting");
			} else {
				Debug.Log ("Enemy unit acting");
				currentUnit.GetComponent<EnemyUnitAction> ().act ();
			}
		} else {
			this.nextTurn ();
		}

	}

	IEnumerator LevelUpPanel(GameObject panel1)
		{
		panel1.SetActive (true);

		this.enemyEncounter.GetComponent<CollectReward> ().collectReward ();

		yield return null;
		}
}
