using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SelectUnit : MonoBehaviour
{

    public static bool onetime = false;

    public bool HUDneedsflashing = false;

    public static int frameSpacer;

    public GameObject currentUnit;

	public Button PartyTarget1Button;
	public Button PartyTarget2Button;

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

	//Called by BattleItemButton.cs
	public void selectItem (GameObject Item)
	{
		this.currentUnit.GetComponent<PlayerUnitAction> ().selectItem (Item);
		this.actionsMenu.SetActive (false);
		//Make Party frame buttons interactable, and add callback to Select Unit
		setPartyTargetsActive ();
	}

    public void attackEnemyTarget(GameObject target)
    {
        this.actionsMenu.SetActive(false);
        this.enemyUnitsMenu.SetActive(false);

        this.currentUnit.GetComponent<PlayerUnitAction>().act(target);

    }

	//called after you click on a player target, carries out the action in PlayerUnitAction
	public void actionPlayerTarget(GameObject target)
	{
		PartyTarget1Button.interactable = false;
		PartyTarget2Button.interactable = false;

		this.currentUnit.GetComponent<PlayerUnitAction> ().actionOnPlayerTarget (target);
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

	public void setPartyTargetsActive()
	{ 
		//gets Frame1 button PlayerUnitInformation Menu
		GameObject GetFrame1 = BattleEventSystem.HighlightCommands.transform.GetChild(2).transform.GetChild(0).gameObject;
		PartyTarget1Button = GetFrame1.gameObject.GetComponent<Button> ();
		//Gets Frame2 Button in the PlayerUnitInformation Menu
		GameObject GetFrame2 = BattleEventSystem.HighlightCommands.transform.GetChild (2).transform.GetChild (1).gameObject;
		PartyTarget2Button = GetFrame2.gameObject.GetComponent<Button> (); 
		//Sets the Players Unit Frames as Clickable
		PartyTarget1Button.interactable = true;
		PartyTarget2Button.interactable = true;
		//Sets the controller to hover over the first frame in the list.
		//EventSystem.current.SetSelectedGameObject(PartyTarget1);
	}

    private void OnDisable()
    {
        onetime = false;
    }

}