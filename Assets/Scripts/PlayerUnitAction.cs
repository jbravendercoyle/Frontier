using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerUnitAction : MonoBehaviour {

	[SerializeField]
	private GameObject physicalAttack;

	[SerializeField]
	private GameObject magicalAttack;

    public GameObject Frame;

    [SerializeField]
    private string unitName;

    private GameObject currentAttack;

    GameObject playerUnitInformationHUD;

    public int frameExists = 0;

	void Awake () {

        this.physicalAttack = Instantiate (this.physicalAttack, this.transform) as GameObject;
		this.magicalAttack = Instantiate (this.magicalAttack, this.transform) as GameObject;

		this.physicalAttack.GetComponent<AttackTarget> ().owner = this.gameObject;
		this.magicalAttack.GetComponent<AttackTarget> ().owner = this.gameObject;

		this.currentAttack = this.physicalAttack;
    }



    public void selectAttack(bool physical) {
		this.currentAttack = (physical) ? this.physicalAttack : this.magicalAttack;
	}

	public void act(GameObject target) {
		this.currentAttack.GetComponent<AttackTarget> ().hit (target);
	}

    public void updateHUD() {

        if (frameExists == 0)
        {
            playerUnitInformationHUD = GameObject.Find("PlayerUnitInformation");
            Frame = Instantiate(this.Frame, this.transform) as GameObject;
            Frame.transform.parent = playerUnitInformationHUD.transform;
            frameExists = 1;
        }

        //Changes colour of current unit frame
        GameObject CurrentUnitFrame = Frame;
	    CurrentUnitFrame.GetComponent<Image> ().color = new Color(0.2F, 0.3F, 0.4F);
            
        //Unit Frame Information
        GameObject playerUnitName = Frame.transform.Find("PlayerUnitName").gameObject;
        playerUnitName.GetComponent<Text>().text = this.unitName;

        GameObject playerUnitHealthBar = Frame.transform.Find("PlayerUnitHealthBar").gameObject;
        playerUnitHealthBar.GetComponent<ShowUnitHP>().changeUnit (this.gameObject);

        GameObject playerUnitManaBar = Frame.transform.Find("PlayerUnitManaBar").gameObject;
        playerUnitManaBar.GetComponent<ShowUnitMP>().changeUnit (this.gameObject);
        }
    }
