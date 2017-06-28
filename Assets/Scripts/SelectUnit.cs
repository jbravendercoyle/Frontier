using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SelectUnit : MonoBehaviour
{

    public static bool onetime = false;

    public bool HUDneedsflashing = false;

    public static int frameSpacer;

    public GameObject currentUnit;

    public GameObject[] allUnits;

    private GameObject actionsMenu, enemyUnitsMenu;


    void Awake()
    {
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


    public void selectCurrentUnit(GameObject unit)
    {
        if (HUDneedsflashing == false)
        {
            this.currentUnit = unit;

            this.actionsMenu.SetActive(true);

            HUDneedsflashing = true;
        }
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

    void Update()
	{
		allUnits = GameObject.FindGameObjectsWithTag ("PlayerUnit");
		if (!onetime) {
			CreateFrames ();
			onetime = true;
		}
	
        if (HUDneedsflashing == true)
            {
            flashHUD();
        }
    }

    void CreateFrames()
    {
        frameSpacer = 0;
        foreach (GameObject unit in allUnits)
        {

            unit.GetComponent<PlayerUnitAction>().createFrames();
            frameSpacer += 1;
        }
    }

        void flashHUD()
	{
		foreach (GameObject unit in allUnits) {
			if (unit != currentUnit) {
				unit.GetComponent<PlayerUnitAction> ().resetHUD ();
				HUDneedsflashing = false;
			}
			if (unit == currentUnit) { 
				this.currentUnit.GetComponent<PlayerUnitAction> ().updateHUD ();
				this.actionsMenu.SetActive(true);
			}
		} 
	}


    private void OnDisable()
    {
        onetime = false;
    }

}