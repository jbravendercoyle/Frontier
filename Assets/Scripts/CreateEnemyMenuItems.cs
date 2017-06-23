using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreateEnemyMenuItems : MonoBehaviour {

	[SerializeField]
	private GameObject targetEnemyUnitPrefab;

	[SerializeField]
	private KillEnemy killEnemyScript;

    [SerializeField]
    private Vector2 initialPosition;

    private Vector2 tooltipLocation;

	// Use this for initialization
	void Awake () {
		GameObject enemyUnitsMenu = GameObject.Find ("EnemyUnitsMenu");

		GameObject[] existingItems = GameObject.FindGameObjectsWithTag ("TargetEnemyUnit");

		GameObject targetEnemyUnit = Instantiate (this.targetEnemyUnitPrefab, enemyUnitsMenu.transform) as GameObject;
		targetEnemyUnit.name = "Target" + this.gameObject.name;
        tooltipLocation = new Vector2(this.initialPosition.x, this.initialPosition.y);
        targetEnemyUnit.transform.localPosition = tooltipLocation;
        //foreach (GameObject item in existingItems)
        //{
            //position of tooltip           
        //    targetEnemyUnit.transform.localPosition = tooltipLocation;
       // }
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
