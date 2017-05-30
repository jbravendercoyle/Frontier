using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreateEnemyMenuItems : MonoBehaviour {

	[SerializeField]
	private GameObject targetEnemyUnitPrefab;

	[SerializeField]
	private KillEnemy killEnemyScript;

	// Use this for initialization
	void Awake () {
		GameObject enemyUnitsMenu = GameObject.Find ("EnemyUnitsMenu");

		GameObject[] existingItems = GameObject.FindGameObjectsWithTag ("TargetEnemyUnit");

		GameObject targetEnemyUnit = Instantiate (this.targetEnemyUnitPrefab, enemyUnitsMenu.transform) as GameObject;
		targetEnemyUnit.name = "Target" + this.gameObject.name;

        foreach (GameObject item in existingItems)
        {
            //position of tooltip
            targetEnemyUnit.transform.localPosition = new Vector2(this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y);
        }
        //scale of tooltip
        targetEnemyUnit.transform.localScale = new Vector2 (0.7f, 0.7f);
		targetEnemyUnit.GetComponent<Button> ().onClick.AddListener (() => 
			selectEnemyTarget());
        //Tooltip name is defined by the Monster Names script attached to the monster - for now
        targetEnemyUnit.GetComponent<Text>().text = this.gameObject.GetComponent<MonsterNames>().Name;


        killEnemyScript.menuItem = targetEnemyUnit;
	}

	public void selectEnemyTarget() {
		GameObject partyData = GameObject.Find ("PlayerParty");
		partyData.GetComponent<SelectUnit> ().attackEnemyTarget (this.gameObject);
	}

}
