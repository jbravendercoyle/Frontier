using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerUnitAction : MonoBehaviour
{

    [SerializeField]
    public GameObject physicalAttack;

    [SerializeField]
    private GameObject magicalAttack;

    public GameObject Frame;

    private GameObject _instance;

    [SerializeField]
    public string unitName;

    int frameSpacer;  

    private GameObject currentAttack;
	public  GameObject currentItem;

    GameObject playerUnitInformationHUD;


    void Awake()
    {

        this.physicalAttack = Instantiate(this.physicalAttack, this.transform) as GameObject;
        this.magicalAttack = Instantiate(this.magicalAttack, this.transform) as GameObject;


        this.physicalAttack.GetComponent<AttackTarget>().owner = this.gameObject;
        this.magicalAttack.GetComponent<AttackTarget>().owner = this.gameObject;

        this.currentAttack = this.physicalAttack;
    }

    public void selectAttack(bool physical)
    {
        this.currentAttack = (physical) ? this.physicalAttack : this.magicalAttack;
    }

	//called by SelectUnit
	public void selectItem(GameObject Item)
	{
		this.currentItem = Item;
	}
    public void act(GameObject target)
    {
        this.currentAttack.GetComponent<AttackTarget>().hit(target);
    } 

	//put item version of act here
	//called by Select Unit / action Player Target, adter you've clicked on a Player Target.
	public void actionOnPlayerTarget(GameObject target)
	{
		this.currentItem.GetComponent<HealTarget> ().healTarget (target);
	}

    public void createFrames ()
	{
		frameSpacer = SelectUnit.frameSpacer;

		playerUnitInformationHUD = GameObject.Find ("PlayerUnitInformation");


		//determines how each frame is spaced
		if (frameSpacer == 0) {
			_instance = Instantiate (this.Frame, new Vector3 (500, 500), Quaternion.identity);
			_instance.transform.SetParent (playerUnitInformationHUD.transform, false);
		}

		if (frameSpacer == 1) {
			_instance = Instantiate (this.Frame, new Vector3 (500, 350), Quaternion.identity);
			_instance.transform.SetParent (playerUnitInformationHUD.transform, false);
		}
		if (frameSpacer == 2) {
			_instance = Instantiate (this.Frame, new Vector3 (500, 200), Quaternion.identity);
		_instance.transform.SetParent (playerUnitInformationHUD.transform, false);
	}
        //Unit Frame Information
        GameObject playerUnitName = _instance.transform.Find("PlayerUnitName").gameObject;
            playerUnitName.GetComponent<Text>().text = this.unitName;

            GameObject playerUnitHealthBar = _instance.transform.Find("PlayerUnitHealthBar").gameObject;
            playerUnitHealthBar.GetComponent<ShowUnitHP>().changeUnit(this.gameObject);

            GameObject playerUnitManaBar = _instance.transform.Find("PlayerUnitManaBar").gameObject;
            playerUnitManaBar.GetComponent<ShowUnitMP>().changeUnit(this.gameObject);

        //hopefully, set default colour for frame
        GameObject CurrentUnitFrame = this._instance;
        CurrentUnitFrame.GetComponent<Image>().color = new Color(0.2F, 0.3F, 0.4F);

    }

	public void updateHUD()
    {
        //var pointer = new PointerEventData(EventSystem.current); //pointer event to execute
        
        //Changes colour of current unit frame

		GameObject CurrentUnitFrame = this._instance;
		Debug.Log ("the update HUD is calling: " + CurrentUnitFrame);
        CurrentUnitFrame.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);

        //ExecuteEvents.Execute(this._instance, pointer, ExecuteEvents.pointerEnterHandler);
        //ExecuteEvents.Execute(this._instance, pointer, ExecuteEvents.pointerDownHandler);

    }

    public void resetHUD()
    {
        //var pointer = new PointerEventData(EventSystem.current); //pointer event to execute
        //Debug.Log("I exist");
        //Changes colour of current unit frame
        GameObject CurrentUnitFrame = this._instance;
        CurrentUnitFrame.GetComponent<Image>().color = new Color(0.2F, 0.3F, 0.4F);
        //ExecuteEvents.Execute(this._instance, pointer, ExecuteEvents.pointerUpHandler);
        //ExecuteEvents.Execute(this._instance, pointer, ExecuteEvents.pointerExitHandler);
    }
}