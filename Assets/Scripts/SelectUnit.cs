using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SelectUnit : MonoBehaviour {

private GameObject currentUnit;

private GameObject actionsMenu, enemyUnitsMenu;

//private GameObject unitForFrameSetup;


    void Awake() {
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Battle")
        {
            this.actionsMenu = GameObject.Find("ActionsMenu");
            this.enemyUnitsMenu = GameObject.Find("EnemyUnitsMenu");

        }
    }

    //trying to set up frames, delete if not working
    //private void frameSetup(GameObject unitForFrameSetup)
    //{
        //might stuff up enemy encounter
    //    this.unitForFrameSetup = GameObject.FindGameObjectWithTag("PlayerUnit");
    //    this.unitForFrameSetup.GetComponent<PlayerUnitAction>().frameSetup();
    //}


    public void selectCurrentUnit(GameObject unit) {
            this.currentUnit = unit;

            this.actionsMenu.SetActive(true);           

            this.currentUnit.GetComponent<PlayerUnitAction>().updateHUD();
        }

    public void selectAttack(bool physical)
    {
        this.currentUnit.GetComponent<PlayerUnitAction>().selectAttack(physical);

        this.actionsMenu.SetActive(false);
        this.enemyUnitsMenu.SetActive(true);
    }

    public void attackEnemyTarget(GameObject target)
    {
        this.actionsMenu.SetActive(false);
        this.enemyUnitsMenu.SetActive(false);

        this.currentUnit.GetComponent<PlayerUnitAction>().act(target);
    }

}
