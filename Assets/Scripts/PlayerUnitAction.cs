using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerUnitAction : MonoBehaviour
{

    [SerializeField]
    private GameObject physicalAttack;

    [SerializeField]
    private GameObject magicalAttack;

    public GameObject Frame;

    private GameObject _instance;

    [SerializeField]
    public string unitName;

    private GameObject currentAttack;

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

    public void act(GameObject target)
    {
        this.currentAttack.GetComponent<AttackTarget>().hit(target);
    }


    public void createFrames()
    {

            playerUnitInformationHUD = GameObject.Find("PlayerUnitInformation");
        for (int i = 0; i < 1; i++)
        {
            _instance = Instantiate(this.Frame, new Vector3(i * 50.0F, 0, 0), Quaternion.identity);
            _instance.transform.parent = playerUnitInformationHUD.transform;
        }
  
        //Unit Frame Information
        GameObject playerUnitName = _instance.transform.Find("PlayerUnitName").gameObject;
        playerUnitName.GetComponent<Text>().text = this.unitName;

        GameObject playerUnitHealthBar = _instance.transform.Find("PlayerUnitHealthBar").gameObject;
        playerUnitHealthBar.GetComponent<ShowUnitHP>().changeUnit(this.gameObject);

        GameObject playerUnitManaBar = _instance.transform.Find("PlayerUnitManaBar").gameObject;
        playerUnitManaBar.GetComponent<ShowUnitMP>().changeUnit(this.gameObject);
    }

    public void updateHUD()
    {
        //Changes colour of current unit frame
        GameObject CurrentUnitFrame = this._instance;
        CurrentUnitFrame.GetComponent<Image>().color = new Color(0.2F, 0.3F, 0.4F);
    }

}